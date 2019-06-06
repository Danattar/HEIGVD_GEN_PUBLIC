﻿using GTTServiceContract.Task;
using GTTServiceContract.TaskImplementation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GTTServerBackend
{
    public class TaskManager : ITaskManager
    {
        private static readonly List<TaskItem> _taskList = new List<TaskItem>();
        private static List<string> _users = new List<String>();

        public TaskManager()
        {
        }
      
        public TaskItem AddTask(string brief, string summary, string assignedUser, string reviewer, 
                                DateTime dueDate, TaskType taskType)
        {
            TaskItem task = CreateTask(brief, summary, assignedUser, reviewer, dueDate, taskType);
            _taskList.Add(task);

            Console.WriteLine("Task Added : \nBrief : " + brief + "\nAssignee : " + assignedUser);
            return task;
        }
        public TaskItem GetTask(int taskID)
        {
            return _taskList.Where(x => x.ID == taskID).FirstOrDefault();
        }
        public TaskItem[] GetTaskAssignedToUser(string user)
        {
            return _taskList.Where(x => x.Assignee == user).ToArray();
        }
        public void DeleteTask(int taskId)
        {
            try
            {
                _taskList.Remove(_taskList.Where(x => x.ID == taskId).First());
            }
            catch
            {
                Console.WriteLine("Task " + taskId + " doesn't exist. It can't be removed");
            }
        }
        public void AssignTaskToUser(int taskId, string newUser)
        {
            try
            {
                _taskList.Where(x => x.ID == taskId).First().Assignee = newUser;

            }
            catch
            {
                Console.WriteLine("Task " + taskId + " doesn't exist. It can't be updated.");
            }
        }

        public void LoggedInAs(string loginScreenUsername)
        {
            if(_users.Where(x=> x == loginScreenUsername).Count() == 0)
                _users.Add(loginScreenUsername);
            Console.WriteLine("Logged in as : " + loginScreenUsername);
        }

        public List<string> GetAllUsers()
        {
            return _users;
        }


        #region Factory

        private TaskItem CreateTask(string brief, string summary, string assignedUser, string reviewer, DateTime dueDate, TaskType taskType)
        {
            return new TaskItem(brief, summary, assignedUser, reviewer, dueDate, taskType);
        }

        #endregion
    }
}
