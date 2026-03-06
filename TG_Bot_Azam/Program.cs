using _12345;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TG_Bot_Azam
{
    internal class Program
    {
        static TelegramBotClient bot = new TelegramBotClient("8326940603:AAH4FsMqHbYBO1hx1z5RB19qqoSfzXKeWTA");
        static async Task Main(string[] args)
        {
            
            var me = await bot.GetMe();
            Console.WriteLine($"BOT is {me.FirstName}.");

            //Question question = new Question();
            


            bot.OnUpdate += Bot_OnUpdate;

            Console.ReadKey();
        }

        private static async Task Bot_OnUpdate(Update update)
        {
            if (update.Message.Text == "/start")
            {
                await bot.SendMessage(update.Message.Chat.Id, "2+2*2");
            }
            else
            {
                if (update.Message.Text == "6")
                {
                    await bot.SendMessage(update.Message.Chat.Id, "Молорик");
                }
                else
                {
                    await bot.SendMessage(update.Message.Chat.Id, "дурик");
                }
            }
            
        }
    }
    
}
