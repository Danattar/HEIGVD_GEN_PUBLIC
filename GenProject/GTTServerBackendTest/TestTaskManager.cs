using GTTServerBackend;
using GTTServiceContract.TaskImplementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
        public void Test_Add_Task_and_check_if_expected_brief__Same_Brief()
        {
            var expectedBrief = "brief";

            TaskItem task = _taskMgr.AddTask(expectedBrief, "a", _user1, "b", DateTime.Now, TaskType.Task);

            var actual = _taskMgr.GetTask(task.ID).Brief;

            Assert.AreEqual(expectedBrief, actual);
        }

        [TestCleanup]
        public void tearDown()
        {
        }
    }
}
