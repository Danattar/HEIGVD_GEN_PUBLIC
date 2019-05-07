using JKang.IpcServiceFramework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GTTServiceContract.Task;
using GTTClientBackend.Services;
using GTTClientBackend.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GTTClientBackendTest
{
    [TestClass]
    public class TaskServiceTest
    {

        //  private IpcServiceClient<ITaskManager> _client;

        private TaskService _taskService;
        [TestInitialize]
        public void setUp()
        {
             _taskService = new TaskService();

            /*   _client = new IpcServiceClientBuilder<ITaskManager>()
                  .UseNamedPipe("pipeName")
                  .Build();
               System.Net.IPAddress serverIP = IPAddress.Parse("192.168.0.234");
               */


            /*          _client = new IpcServiceClientBuilder<IRoomManager>()
                          .UseTcp(serverIP, 45684)
                          .Build();
                      Assert.IsNotNull(_client);
             */
        }

      /*  [TestMethod]
        public void testConnection_by_IP__OK()
        {
            System.Net.IPAddress serverIP = IPAddress.Parse("192.168.0.234");
            _client = new IpcServiceClientBuilder<ITaskManager>()
                .UseTcp(serverIP, 45684)
                .Build();
            Assert.IsNotNull(_client);
        }*/

        [TestMethod]
        public async Task AddTask__Brief_equals_TaskCreatedByUnitTest__OK()
        {
            string taskBrief = "TaskCreatedByUnitTest";
            /*
            ITaskItem task1 = await _client.InvokeAsync(x => x.AddTask(taskBrief,
                "This is a task created by a unit test", "user1"));
            ITaskItem taskGetById = await _client.InvokeAsync(x => x.GetTask(task1.ID));*/
            TaskBox task1 = await _taskService.GetNewTaskBoxAsync(taskBrief,
                "This is a task created by a unit test", "user1");
            TaskBox taskGetById = await _taskService.GetTaskBox(task1.ID);
            Assert.AreEqual(taskBrief, taskGetById.Brief);
        }
    }
}
