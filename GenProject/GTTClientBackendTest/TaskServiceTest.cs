using JKang.IpcServiceFramework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GTTServiceContract.Task;
using GTTClientBackend.Services;
using GTTClientBackend.Models;
using GTTServiceContract.TaskImplementation;
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
                "This is a task created by a unit test", "user1", "user1", DateTime.Today, TaskType.Task);
            TaskBox taskGetById = await _taskService.GetTaskBox(task1.ID);
            Assert.AreEqual(taskBrief, taskGetById.Brief);
        }


        [TestMethod]
        public async Task GetTaskBoxListForUser__user_task_retrieved_count_is_2__OK()
        {
            string user1 = "simon";
            string user2 = "fred";
            await _taskService.GetNewTaskBoxAsync("test task1",
                "This is a task created by a unit test", user1, user2,DateTime.Today, TaskType.Task);
            await _taskService.GetNewTaskBoxAsync("test task2",
                "This is a task created by a unit test", user2, user1, DateTime.Today, TaskType.Task);
            await _taskService.GetNewTaskBoxAsync("test task3",
                "This is a task created by a unit test", user1, user2, DateTime.Today, TaskType.Task);

            List<TaskBox> userTask = await _taskService.GetTaskBoxListForUser(user1);
            Assert.AreEqual(userTask.Count, 2);
        }

        [TestMethod]
        public async Task AssignTask__Task_is_assigned_to_other_user__OK()
        {
            string user1 = "simon";
            string user2 = "fred";
            TaskBox task1 = await _taskService.GetNewTaskBoxAsync("test task assignment",
                "This is a task created by a unit test", user1, user2, DateTime.Today, TaskType.Task);
            TaskBox task2 = await _taskService.GetNewTaskBoxAsync("test task assignment2",
                "This is a task created by a unit test", user2, user2, DateTime.Today, TaskType.Task);

            List<TaskBox> userTask = await _taskService.GetTaskBoxListForUser(user1);
            Assert.AreEqual(userTask.Count, 1);

            await _taskService.AssignTask(task2.ID, user1);
            userTask = await _taskService.GetTaskBoxListForUser(user1);

            Assert.AreEqual(userTask.Count, 2);
        }

        [TestMethod]
        public async Task tTaskBoxListForUser__user_task_retrieved_count_is_2__OK()
        {

        }

    }
}
