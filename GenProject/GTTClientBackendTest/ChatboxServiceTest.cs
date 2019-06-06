using GTTClientBackend.Models;
using GTTClientBackend.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;


namespace GTTClientBackendTest
{

    [TestClass]
    public class ChatboxServiceTest
    {
        private ChatBoxService _chatBoxService;

        [TestInitialize]
        public void setUp()
        {
            _chatBoxService = new ChatBoxService();
        }

        [TestMethod]
        public async Task TestGetNewChatBox__ChatBox_not_null()
        {
            ChatBox chatBox = await _chatBoxService.GetNewChatBoxAsync();
            Assert.AreNotEqual(null, chatBox);
        }

        [TestMethod]
        public async Task TestGetNewChatBox_by_existing_roomID___Two_ChatBox_refer_to_same_roomId()
        {
            ChatBox chatBox = await _chatBoxService.GetNewChatBoxAsync();
            ChatBox chatBox2 = await _chatBoxService.GetNewChatBoxAsync(chatBox.RoomID);
            Assert.AreEqual(chatBox.RoomID, chatBox2.RoomID);
        }

        [TestMethod]
        public async Task TestAddMessage___chatBox_received_new_message()
        {
            ChatBox chatBox = await _chatBoxService.GetNewChatBoxAsync();

            ChatBox chatBox2 = await _chatBoxService.GetNewChatBoxAsync(chatBox.RoomID);
            await _chatBoxService.AddMessage(chatBox.RoomID, "author1", "message1");

            ChatBox chatBox3 = await _chatBoxService.GetNewChatBoxAsync(chatBox.RoomID);

            Assert.AreEqual(chatBox3.RoomMessageList[chatBox3.RoomMessageList.Count - 1].Message, "message1");
        }

        [TestMethod]
        public async Task Test_Get_Two_ChatBox_Same_ID__OK()
        {
            var chatBox1 = await _chatBoxService.GetNewChatBoxAsync();
            var chatBox2 = await _chatBoxService.GetNewChatBoxAsync(chatBox1.RoomID);
            Assert.AreEqual(chatBox1.RoomID, chatBox2.RoomID, "ERROR: room1.RoomID is diffrent then room2.RoomID");
        }
    }
}
