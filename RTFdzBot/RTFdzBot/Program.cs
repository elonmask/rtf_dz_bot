using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace RTFdzBot
{

    class Program
    {

        static ITelegramBotClient botClient;
        const string TOKEN = "628193833:AAGwvD39F3PaYphm7qOkVwgNLktblvvjITI";
        const int ADMIN_ID = 12345;

        static void Main(string[] args)
        {

            botClient = new TelegramBotClient(TOKEN);

            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            Thread.Sleep(int.MaxValue);

        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {

                if (e.Message.From.Id == ADMIN_ID)
                {
                    Console.WriteLine("Message from Admin");

                    if (e.Message.Text == "/send_hw")
                    {
                        await botClient.SendTextMessageAsync(
                            chatId: e.Message.Chat,
                            text: "Отправь мне д/з в формате:  ;Номер группы;Дата, на которую нужно выполнить задание;Предмет;Текст задания;"
                          );
                    } else if (e.Message.Text != "/send_hw" && e.Message.Text != "/start")
                    {
                        //Тут мы сохраняем дз в базу
                    }

                } else
                {
                    if (e.Message.Text == "/start")
                    {
                        await botClient.SendTextMessageAsync(
                            chatId: e.Message.Chat,
                            text: "Отправь мне номер своей группы"
                          );
                    } else if (e.Message.Text != "/start" && e.Message.Text != "/today" && e.Message.Text != "/tomorrow" && e.Message.Text != "/week" && e.Message.Text != "/next_week")
                    {
                        string txt = e.Message.Text;

                        if (txt[0] == 'Р' || txt[0] == 'р')
                        {
                            await botClient.SendTextMessageAsync(
                            chatId: e.Message.Chat,
                            text: "Теперь дай мне знать на какой день/дни ты хочешь получить задание: \n\n/today\n/tomorrow\n/week\n/next_week"
                          );
                        }
                    } else if (e.Message.Text == "/tommorow")
                    {
                        /*
                        Тут мы формируем ответ и отправляем его в ответ пользователю    
                     */
                    } else if (e.Message.Text == "/today")
                    {
                        /*
                        Тут мы формируем ответ и отправляем его в ответ пользователю    
                     */
                    }
                }
            }
        }
    }
}
