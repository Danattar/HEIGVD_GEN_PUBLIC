using GenProjectClientBackend.Models;
using GenProjectClientBackend.ServiceProjectMock;
using GenProjectClientBackend.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenProjectClientBackendTest
{
    [TestClass]
    public class RoomManagerTest
    {
        private ChatBox _chatbox1;
        private ChatBox _chatbox2;
        private ChatBoxService _chatBoxService;
        private string _testMessage = "test01";

        [TestInitialize]
        public void SetUp()
        {
            _chatBoxService = new ChatBoxService(new RoomManager());
        }
        [TestMethod]
        public void Test_Communication_Two_ChatBox()
        {
            _chatbox1 = _chatBoxService.GetNewChatBox();
            _chatbox2 = _chatBoxService.GetChatBox(_chatbox1.RoomID);
            _chatBoxService.AddMessage(_chatbox1.RoomID, _testMessage, "saumon");
            Assert.AreEqual(_testMessage, _chatbox2.MessageList.FindLast(x => true).Message);
        }

        [TestMethod]
        public void Test_Communication_Two_ChatBox2()
        {
            _chatbox1 = _chatBoxService.GetNewChatBox();
            _chatBoxService.AddMessage(_chatbox1.RoomID, _testMessage, "saumon");
            _chatbox2 = _chatBoxService.GetChatBox(_chatbox1.RoomID);

            Assert.AreEqual(_testMessage, _chatbox2.MessageList.FindLast(x => true).Message);
        }


    }
}
