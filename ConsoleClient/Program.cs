using Newtonsoft.Json;
using System;

namespace MyMessenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Message msg = new Message("CNFLKT", "Hello", DateTime.UtcNow);
            string output = JsonConvert.SerializeObject(msg);
            Console.WriteLine(output);

            Message deserializedMsg = JsonConvert.DeserializeObject<Message>(output);
            Console.WriteLine(deserializedMsg);

            //{ "UserName":"CNFLKT","MessageText":"Hello","TimeStamp":"2021-11-06T20:07:03.192628Z"}
            //CNFLKT < 06.11.2021 20:07:03 >: Hello
        }
    }
}
