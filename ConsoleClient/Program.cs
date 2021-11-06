using Newtonsoft.Json;
using System;

namespace MyMessenger
{
    class Program
    {
        private static int MessageID;
        private static string UserName;
        private static MessengerClientAPI API = new MessengerClientAPI();

        private static void GetNewMessages()
        {
            Message msg = API.GetMessage(MessageID);
            while(msg != null)
            {
                Console.WriteLine(msg);
                MessageID++;
                msg = API.GetMessage(MessageID);
            }
        }
        static void Main(string[] args)
        {
            //Message msg = new Message("CNFLKT", "Hello", DateTime.UtcNow);
            //string output = JsonConvert.SerializeObject(msg);
            //Console.WriteLine(output);

            //Message deserializedMsg = JsonConvert.DeserializeObject<Message>(output);
            //Console.WriteLine(deserializedMsg);

            //{ "UserName":"CNFLKT","MessageText":"Hello","TimeStamp":"2021-11-06T20:07:03.192628Z"}
            //CNFLKT < 06.11.2021 20:07:03 >: Hello

            MessageID = 1;
            Console.WriteLine("Введите ваше имя:");
            UserName = Console.ReadLine();
            string MessageText = "";
            while(MessageText != "exit")
            {
                GetNewMessages();
                MessageText = Console.ReadLine();
                if(MessageText.Length > 1)
                {
                    Message Sendmsg = new Message(UserName, MessageText, DateTime.Now);
                    API.SendMessage(Sendmsg);
                }
            }
        }
    }
}
