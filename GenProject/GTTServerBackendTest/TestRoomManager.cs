using GTTServerBackend;
using GTTServiceContract.Room;
using GTTServiceContract.RoomImplementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace GTTServerBackendTest
{
    [TestClass]
    public class TestRoomManager
    {
        private IRoomManager _roomMgr;
        private readonly Guid _user1Guid = Guid.NewGuid();
        private readonly string _user1Name = "fred";
        private readonly Guid _user2Guid = Guid.NewGuid();
        private readonly string _user2Name = "simon";

        [TestInitialize]
        public void setUp()
        {
            _roomMgr = new RoomManager(new RoomQueuesHolder());

        }
        [TestMethod]
        public void Test_Add_Room__OK()
        {
            Room room1 = _roomMgr.AddRoom(_user1Guid);
            Assert.AreNotEqual(null, room1);
        }
        [TestMethod]
        public void Test_Get_Room_For_User_By_clientGuid_roomID__RoomID_As_expected()
        {
            string expectedRoomID = "a12df";
            _roomMgr.GetRoom(expectedRoomID, _user1Guid); //room creation (as roomID does not exist)
            string actualRoomID = _roomMgr.GetRoom(expectedRoomID, _user1Guid).ID; //get existing room
            Assert.AreEqual(expectedRoomID, actualRoomID);
        }

        [TestMethod]
        public void Test_Get_Queud_Message__Get_New_Message_And_Clear_Queue()
        {
            string roomID = "a12df";
            string messageActual1 = "salut";
            string messageActual2 = "coucou";
            Room roomUser1 = _roomMgr.GetRoom(roomID, _user1Guid); //room creation (as roomID does not exist), get it
            Room roomUser2 = _roomMgr.GetRoom(roomID, _user2Guid); //get existing room

            _roomMgr.AddRoomMessage(roomID, _user1Name, messageActual1);
            _roomMgr.AddRoomMessage(roomID, _user2Name, messageActual2);

            Dictionary<string, List<RoomMessage>> queuedMsgUser1 = _roomMgr.GetQueuedMessages(_user1Guid);

            RoomMessage lastRoomMessageExpected = queuedMsgUser1[roomID][queuedMsgUser1[roomID].Count - 1];

            Assert.AreEqual(lastRoomMessageExpected.Message, messageActual2);
            Assert.AreEqual(lastRoomMessageExpected.Author, _user2Name);
        }

    }
}
