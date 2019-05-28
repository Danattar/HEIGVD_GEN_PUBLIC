using System.Net;
using GTTServiceContract.Room;
using JKang.IpcServiceFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace GTTClientBackendTest
{
    [TestClass]
    public class ChatboxServiceTest
    {
        private IpcServiceClient<IRoomManager> _client;
        [TestInitialize]
        public void setUp()
        {
             _client = new IpcServiceClientBuilder<IRoomManager>()
                .UseNamedPipe("pipeName")
                .Build();
            System.Net.IPAddress serverIP = IPAddress.Parse("192.168.0.234");
  /*          _client = new IpcServiceClientBuilder<IRoomManager>()
                .UseTcp(serverIP, 45684)
                .Build();
            Assert.IsNotNull(_client);
   */       }

        [TestMethod]
        public void testConnection_by_IP__OK()
        {
            System.Net.IPAddress serverIP = IPAddress.Parse("192.168.0.234");
            _client = new IpcServiceClientBuilder<IRoomManager>()
                .UseTcp(serverIP, 45684)
                .Build();
            Assert.IsNotNull(_client);
        }

        [TestMethod]
        public async Task TestConnection__OKAsync()
        {
            bool isConnected = await _client.InvokeAsync(x => x.IsConnected());
            Assert.IsTrue(isConnected);
        }

        /// <summary>DO NOT add another test ABOVE this one before reading the following : -- !!!!
        /// <para> Be aware that this test can fail if another client already created called for AddRoom to the same GTTServerBackend process.</para>
        /// </summary>
        /// TODO : implement in the setUp the start of the GTTServerBackend process and in tearDown the stop of the GTTServerBackend process
        [TestMethod]
        public async Task AddRoom__ID_equals_1__OK()
        {
            var a = await _client.InvokeAsync(x => x.AddRoom());
            Assert.AreEqual(1, a.ID) ;
        }
        /// <summary>
        /// This test will should  succeed once above TODO will be implemented
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task AddRoom__ID_equals_1__KO()
        {
            var a = await _client.InvokeAsync(x => x.AddRoom());
            Assert.AreEqual(1, a.ID);
        }

        //Abort, this functionality is out of scope of the project release 1
        /*[TestMethod]
        public async Task AddRoom__Is_Typeof_IRoom__OK()
        {
            var a = await _client.InvokeAsync(x => x.AddRoom());
            Assert.AreEqual(typeof(IRoom), a.GetType());
        }
        */
        [TestMethod]
        public async Task Test_Get_Two_Rooms_Same_ID__OK()
        {
            var room1 = await _client.InvokeAsync(x => x.AddRoom());
            var room2 = await _client.InvokeAsync(x => x.GetRoom(room1.ID));
            Assert.AreEqual(room1.ID, room1.ID,"ERROR: room1.ID is diffrent then room2.ID");
        }
        [TestCleanup]
        public void tearDown()
        {
            _client = null;
        }
    }
}
