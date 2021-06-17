using System;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TelegramBot
{
    internal static class Program 
    {
        static ITelegramBotClient bot;

        private static void Main()
        {
            bot = new TelegramBotClient("1892245518:AAEJWf5NPWkyLbItD-umVI0eO0a6Z4ZlByk");
            bot.OnMessage += FirstOnMessage;
            
            bot.StartReceiving();
            Console.ReadLine();
            bot.StopReceiving();
        }

        static async void FirstOnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text == null) return;
            await bot.SendTextMessageAsync(chatId: e.Message.Chat, text: await NewsParser.FindNews(e.Message.Text));
        }
    }
}