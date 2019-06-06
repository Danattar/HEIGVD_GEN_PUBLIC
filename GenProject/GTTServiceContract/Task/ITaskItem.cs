﻿using GTTServiceContract.TaskImplementation;
using System;

namespace GTTServiceContract.Task
{
    public interface ITaskItem
    {
        int ID { get; }
        string Brief { get; set; }
        string Summary { get; set; }
        string Assignee { get; set; }
        string Reviewer { get; set; }
        DateTime DueDate { get; set; }
        TaskType TaskType { get; set; }
    }
}
