using GTTServiceContract.Task;
using GTTServiceContract.TaskImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTTServerBackend
{
    public class TaskManager : ITaskManager
    {
        private static readonly List<TaskItem> _taskList = new List<TaskItem>();
        public bool IsConnected()
        {
            return true;
        }

        public TaskManager()
        {
            Console.WriteLine("w");
        }

        public TaskItem AddTask(string brief, string summary, string assignedUser)
        {
            TaskItem task = CreateTask(brief, summary, assignedUser);
            _taskList.Add(task);
            Console.WriteLine("Task added");
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
                _taskList.Where(x => x.ID == taskId).First().AssignedUser = newUser;

            }
            catch
            {
                Console.WriteLine("Task " + taskId + " doesn't exist. It can't be updated.");
            }
        }



        #region Factory

        private TaskItem CreateTask(string brief, string summary, string assignedUser)
        {
            return new TaskItem(brief, summary, assignedUser);
        }


        #endregion
    }
}
