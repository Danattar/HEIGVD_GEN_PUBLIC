using GTTServiceContract.Task;
using Newtonsoft.Json;
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
        public string Assignee { get; set; }

        public TaskItem(string brief, string summary, string assignee)
        {
            ID = _nextID++;
            Brief = brief;
            Summary = summary;
            Assignee = assignee;
        }
        [JsonConstructor]
        public TaskItem(int id, string brief, string summary, string assignee)  
        {
            ID = id;
            Brief = brief;
            Summary = summary;
            Assignee = assignee;
        }
    }
}
