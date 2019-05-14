using GTTServiceContract.TaskImplementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTTServiceContract.Task
{
    public interface ITaskManager
    {
        TaskItem AddTask(string brief, string summary, string assignedUser, string reviewer, DateTime dueDate);
        TaskItem GetTask(int taskID);
        TaskItem[] GetTaskAssignedToUser(string user);
        void DeleteTask(int taskId);
        void AssignTaskToUser(int taskId, string newUser);

        //public event Action<IRoom, IRoomMessage> MessageAdded;


        void LoggedInAs(string loginScreenUsername);
        List<string> GetAllUsers();
    }
}
