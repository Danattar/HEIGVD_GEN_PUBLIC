﻿using GTTServiceContract.TaskImplementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTTServiceContract.Task
{
    public interface ITaskManager
    {
        TaskItem AddTask(string brief, string summary, string assignedUser);
        TaskItem GetTask(int taskID);
        List<TaskItem> GetTaskAssignedToUser(string user);
        void DeleteTask(int taskId);
        void AssignTaskToUser(int taskId, string newUser);

        //public event Action<IRoom, IRoomMessage> MessageAdded;


    }
}
