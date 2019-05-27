using System;
using System.Collections.Generic;
using System.Text;
using GTTServiceContract.Task;
using GTTServiceContract.TaskImplementation;

namespace GTTClientBackend.Models
{
    public class TaskBox
    {
        public int ID { get; }
        public string Brief { get; set; }
        public string Summary { get; set; }
        public string Assignee { get; set; }
        public DateTime DueDate { get; set; } = DateTime.Today.AddDays(1);
        public string Reviewer { get; set; }
        public TaskType TaskType { get; set; }

        public TaskBox()
        {
            
        }
        internal TaskBox(int taskID, string brief, string summary, string assignee, string reviewer, DateTime dueDate, TaskType taskType)
        {
            ID = taskID;
            Brief = brief;
            Summary = summary;
            Assignee = assignee;
            Reviewer = reviewer;
            DueDate = dueDate;
            TaskType = taskType;
        }
    }
}
