using GTTServerBackend;
using GTTServiceContract.TaskImplementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTTServerBackendTest
{
    [TestClass]
    public class TestTaskManager
    {
        private TaskManager _taskMgr;
        private string _user1 = "fred";
        private string _user2 = "simon";

        [TestInitialize]
        public void setUp()
        {
            
            _taskMgr = new TaskManager();
        }
        [TestMethod]
        public void TestAddTask__task_with_brief()
        {
            TaskItem task = _taskMgr.AddTask("brief", "a", _user1, "b", DateTime.Now, TaskType.Task); 
            Assert.AreEqual(task.Brief, _taskMgr.GetTask(task.ID).Brief);
        }

        [TestCleanup]
        public void tearDown()
        {
        }
    }
}
