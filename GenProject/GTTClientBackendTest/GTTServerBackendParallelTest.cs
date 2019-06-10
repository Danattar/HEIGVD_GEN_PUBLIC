using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GTTClientBackend.Services;
using GTTClientBackend.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace GTTServerBackendTest
{
    [TestClass]
    public class GTTServerBackendParallelTest
    {
        private ChatBoxService _chatBoxService;
        public TestContext TestContext { get; set; }

        [TestMethod]
        public async Task Test_2_Client_Add_Message_In_ParallelAsync()
        {
            string roomName = "TestRoom";
            string author1 = "frederic";
            string author2 = "simon";
            string author3 = "bob";
            string author4 = "jack";
            string author5 = "mike";
            string message1 = "Salut 1";
            string message2 = "Salut 2";
            string message3 = "Salut 3";
            string message4 = "Salut 4";
            string message5 = "Salut 5";
            var client1 = new ChatBoxService();
            var client2 = new ChatBoxService();
            var client3 = new ChatBoxService();
            var client4 = new ChatBoxService();
            var client5 = new ChatBoxService();
            ChatBox ChatBox1 = await client1.GetNewChatBoxAsync(roomName);
            ChatBox ChatBox2 = await client2.GetNewChatBoxAsync(roomName);
            ChatBox ChatBox3 = await client3.GetNewChatBoxAsync(roomName);
            ChatBox ChatBox4 = await client4.GetNewChatBoxAsync(roomName);
            ChatBox ChatBox5 = await client5.GetNewChatBoxAsync(roomName);
            Parallel.Invoke(() =>
                                {
                                    client1.AddMessage(roomName, author1, message1);
                                },
                                () =>
                                {
                                    client2.AddMessage(roomName, author2, message2);
                                },
                                () =>
                                {
                                    client3.AddMessage(roomName, author3, message3);
                                },
                                 () =>
                                {
                                    client4.AddMessage(roomName, author4, message4);
                                },
                                 () =>
                                {
                                    client5.AddMessage(roomName, author5, message5);
                                }
                             );
            System.Threading.Thread.Sleep(3000);
            TestContext.WriteLine("===========");
            TestContext.WriteLine("ChatBox 1 :");
            ChatBox1.RoomMessageList.ForEach(x => Console.WriteLine(x.Author + " : " + x.Message));
            Console.WriteLine("ChatBox 2 :");
            ChatBox2.RoomMessageList.ForEach(x => Console.WriteLine(x.Author + " : " + x.Message));
        }
    }
}
