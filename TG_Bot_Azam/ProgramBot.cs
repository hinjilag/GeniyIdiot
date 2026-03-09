using _12345;
using Telegram.Bot;
using Telegram.Bot.Types;
using User = _12345.User;

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

        private static Dictionary<long, User> usersDict = new Dictionary<long, User>(); // словарь пользователей
        private static Dictionary<long, string> userStates = new Dictionary<long, string>(); // словарь состояния чата
        private static async Task Bot_OnUpdate(Update update)
        {
            long chatId = update.Message.Chat.Id;
            string text = update.Message.Text;

            if (update.Message.Text == "/start")
            {
                userStates[chatId] = "waiting_for_name";
                await bot.SendMessage(update.Message.Chat.Id,
                    "Добро пожаловать в игру гений-идиот! Как к вам обращаться?");
                return;
            }

            if (usersDict.ContainsKey(chatId)) // такой тип был уже?
            {
                User existingUser = usersDict[chatId];
            }
            else
            {
                if (userStates.TryGetValue(chatId, out string state) && state == "waiting_for_name") // если он находиться в каком то состояни, и это состояние ожидание имени
                {
                    User newUser = new User { Name = text };
                    usersDict[chatId] = newUser;
                    userStates[chatId] = "in_menu";

                    await bot.SendMessage(update.Message.Chat.Id, $"{newUser.Name}, выбери действие (введи номер)");
                    await bot.SendMessage(update.Message.Chat.Id, """
                    1) играть
                    2) смотреть результаты
                    0) выйти из игры
                    """);
                    return;
                }
            }

            if (userStates.TryGetValue(chatId, out string currentState) && currentState == "in_menu")
            {
                // Достаем пользователя из словаря
                User currentUser = usersDict[chatId];

                // Обрабатываем выбор
                if (text == "1")
                {
                    await bot.SendMessage(chatId, "Сейчас начнется игра...");
                    // TODO: запустить игру
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
                    // TODO: может очистить состояние?
                }
                else
                {
                    await bot.SendMessage(chatId, "Такого пункта нет. Введи 1, 2, 3 или 0");
                }

                return;
            }
        }
    }

}
