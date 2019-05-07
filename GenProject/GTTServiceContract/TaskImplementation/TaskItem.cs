using GTTServiceContract.Task;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTTServiceContract.TaskImplementation
{
    public class TaskItem : ITaskItem
    {
        private static int _nextID = 1;
        public int ID { get; }
        public string Brief { get; set; }
        public string Summary { get; set; }
        public string AssignedUser { get; set; }

        public TaskItem(string brief, string summary, string assignedUser)
        {
            ID = _nextID++;
            Brief = brief;
            Summary = summary;
            AssignedUser = assignedUser;
        }

    }
}
