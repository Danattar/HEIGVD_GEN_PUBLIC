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
        private TaskService _taskService;

        [TestInitialize]
        public void setUp()
        {
             _taskService = new TaskService();


        }

        [TestMethod]
        public async Task GetTaskBox__Brief_equals_TaskCreatedByUnitTest__OK()
        {
            string taskBrief = "TaskCreatedByUnitTest";
            TaskBox task1 = await _taskService.GetNewTaskBoxAsync(taskBrief,
                "This is a task created by a unit test", "user1");
            TaskBox taskGetById = await _taskService.GetTaskBox(task1.ID);
            Assert.AreEqual(taskBrief, taskGetById.Brief);
        }


        [TestMethod]
        public async Task GetTaskBoxListForUser__user_task_retrieved_count_is_2__OK()
        {
            string user1 = "simon";
            string user2 = "fred";
            await _taskService.GetNewTaskBoxAsync("test task1",
                "This is a task created by a unit test", user1);
            await _taskService.GetNewTaskBoxAsync("test task2",
                "This is a task created by a unit test", user2);
            await _taskService.GetNewTaskBoxAsync("test task3",
                "This is a task created by a unit test", user1);

            List<TaskBox> userTask = await _taskService.GetTaskBoxListForUser(user1);
            Assert.AreEqual(userTask.Count, 2);
        }

        [TestMethod]
        public async Task AssignTask__Task_is_assigned_to_other_user__OK()
        {
            TaskBox task1 = await _taskService.GetNewTaskBoxAsync("test task assignment",
                "This is a task created by a unit test", "Simon");
            TaskBox task2 = await _taskService.GetNewTaskBoxAsync("test task assignment2",
                "This is a task created by a unit test", "Fred");

        }


    }
}
