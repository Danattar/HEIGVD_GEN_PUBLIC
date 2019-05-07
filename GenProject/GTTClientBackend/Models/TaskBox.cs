using System;
using System.Collections.Generic;
using System.Text;

namespace GTTClientBackend.Models
{
    public class TaskBox
    {
        public int ID { get; }
        public string Brief { get; set; }
        public string Summary { get; set; }
        public string Assignee { get; set; }

        internal TaskBox(int taskID, string brief, string summary, string assignee)
        {
            ID = taskID;
            Brief = brief;
            Summary = summary;
            Assignee = assignee;
        }
    }
}
