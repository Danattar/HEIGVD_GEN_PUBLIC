using GTTServiceContract.TaskImplementation;
using System;
using System.Collections.Generic;

namespace GTTServiceContract.Task
{
    public interface ITaskManager
    {
        TaskItem AddTask(string brief, string summary, string assignedUser, string reviewer, DateTime dueDate, TaskType taskType);
        TaskItem GetTask(int taskID);
        TaskItem[] GetTaskAssignedToUser(string user);
        void DeleteTask(int taskId);
        void AssignTaskToUser(int taskId, string newUser);


        void LoggedInAs(string loginScreenUsername);
        List<string> GetAllUsers();
    }
}
