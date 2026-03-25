using _12345;
using Telegram.Bot;
using Telegram.Bot.Types;
using UserMy = _12345.UserMy;

namespace TG_Bot_Azam
{
    internal class ProgramBot
    {
        static TelegramBotClient bot = new TelegramBotClient("8326940603:AAH4FsMqHbYBO1hx1z5RB19qqoSfzXKeWTA");
        static async Task Main(string[] args)
        {

            var me = await bot.GetMe();
            Console.WriteLine($"BOT is {me.FirstName}.");

            bot.OnUpdate += Bot_OnUpdate;

            Console.ReadKey();
        }

        private static Dictionary<long, UserMy> usersDict = new Dictionary<long, UserMy>(); // словарь пользователей
        private static Dictionary<long, string> userStates = new Dictionary<long, string>(); // словарь состояния чата
        private static Dictionary<long, List<Question>> userQuestions = new Dictionary<long, List<Question>>(); // вопросы для текущей игры
        private static Dictionary<long, int> userQuestionIndex = new Dictionary<long, int>(); // на каком вопросе пользователь
        private static Dictionary<long, List<string>> userAnswers = new Dictionary<long, List<string>>(); // ответы пользователя


        private static async Task Bot_OnUpdate(Update update)
        {
            long chatId = update.Message.Chat.Id;
            string text = update.Message.Text;

            if (text == "/start")
            {
                userStates[chatId] = "waiting_for_name";
                await bot.SendMessage(chatId,
                    "Добро пожаловать в игру гений-идиот! Как к вам обращаться?");
                return;

            }
            
            if (usersDict.ContainsKey(chatId)) // такой тип был уже?  почему нельзя написать userStates[chatId] != null
            {
                UserMy existingUser = usersDict[chatId];
            }
            else
            {
                if (userStates[chatId] == "waiting_for_name")
                {
                    UserMy newUser = new UserMy { };
                    newUser.Name = text;
                    usersDict[chatId] = newUser;
                    userStates[chatId] = "in_menu";

                    await bot.SendMessage(chatId, $"{newUser.Name}, выбери действие (введи номер)");
                    await bot.SendMessage(chatId, """
                    1) играть
                    2) смотреть результаты
                    3) вход для админа
                    0) выйти из игры
                    """);
                    return;
                }
            }

            if (userStates[chatId] == "in_menu")
            {
                // Достаем пользователя из словаря
                UserMy currentUser = usersDict[chatId];

                // Обрабатываем выбор
                if (text == "1")
                {
                    await bot.SendMessage(chatId, "Сейчас начнется игра");
                    userStates[chatId] = "playing";
                    List<Question> questions = QuestionsStorage.GetRandomQuestions(3); // получаем вопросики


                    if (questions.Count == 0)
                    {
                        await bot.SendMessage(chatId, "Ошибка!!! вопросы не найдены в файле questions.json");
                        userStates[chatId] = "in_menu"; // возвращаем в меню
                        return;
                    }
                    userQuestions[chatId] = questions;
                    userQuestionIndex[chatId] = 0;
                    userAnswers[chatId] = new List<string>();

                    Question firstQuestion = questions[0];
                    await bot.SendMessage(chatId, $"Вопрос 1 из {questions.Count}:");
                    await bot.SendMessage(chatId, firstQuestion.Text);

                    return;

                }
                else if (text == "2")
                {
                    await bot.SendMessage(chatId, "Смотрим результаты...");
                    // TODO: показать результаты
                }
                else if (text == "3")
                {
                    await bot.SendMessage(chatId, "Вход для админа...");
                    // TODO: админка
                }
                else if (text == "0")
                {
                    await bot.SendMessage(chatId, "дзабах ут");

                }
                else
                {
                    await bot.SendMessage(chatId, "Такого пункта нет. Введи 1, 2, 3 или 0");
                }

                return;
            }
            // 3. ПРОЦЕСС ИГРЫ (ОБРАБОТКА ОТВЕТОВ)

            if (userStates[chatId] == "playing")
            {
                List<Question> questions = userQuestions[chatId];
                int currentIndex = userQuestionIndex[chatId];

                // Сохраняем текст сообщения как ответ
                userAnswers[chatId].Add(text);

                // Переходим к следующему вопросу
                currentIndex++;
                userQuestionIndex[chatId] = currentIndex;

                if (currentIndex < questions.Count)
                {
                    // Задаем следующий вопрос
                    await bot.SendMessage(chatId, $"Вопрос {currentIndex + 1} из {questions.Count}:");
                    await bot.SendMessage(chatId, questions[currentIndex].Text);
                }
                else
                {
                    // Если вопросы кончились
                    await bot.SendMessage(chatId, "Все вопросы пройдены! Считаем результаты...");

                    // Временно переводим в меню, чтобы не зациклиться
                    userStates[chatId] = "in_menu";
                    await bot.SendMessage(chatId, "Введите 1, чтобы играть снова, или 0 для выхода.");
                }
                return;
            }
        }
    }

}
