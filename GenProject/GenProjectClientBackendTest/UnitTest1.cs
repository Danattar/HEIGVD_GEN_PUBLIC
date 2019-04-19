using GenProjectClientBackend.Models;
using GenProjectClientBackend.ServiceProjectMock;
using GenProjectClientBackend.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenProjectClientBackendTest
{
    [TestClass]
    public class RoomManagerTest
    {
        private Chatbox _chatbox1;
        private Chatbox _chatbox2;
        private ChatBoxService _chatBoxService;

        [TestInitialize]
        public void SetUp()
        {
            _chatBoxService = new ChatBoxService(new RoomManager());
        }
        [TestMethod]
        public void Test_Communication_Two_ChatBox()
        {
            string message = "test01";
            _chatbox1 = _chatBoxService.GetNewChatBox();
            _chatbox2 = _chatBoxService.GetChatBox(_chatbox1.RoomID);
            _chatBoxService.AddMessage(_chatbox1.RoomID, message, "saumon");
            Assert.AreEqual(message, _chatbox2.MessageList.FindLast(x => true).Message);
        }


    }
}
