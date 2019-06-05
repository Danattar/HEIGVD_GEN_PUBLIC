using GTTServerBackend;
using GTTServiceContract.Room;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTTServerBackendTest
{
    [TestClass]
    public class TestRoomManager
    {
        private IRoomManager _roomMgr;

        [TestInitialize]
        public void setUp()
        {
            _roomMgr = new RoomManager(new RoomQueuesHolder());
        }
        [TestMethod]
        public void TestAddRoom__RoomCreated()
        {
        //    _roomMgr.AddRoom("1");

        }
    }
}
