using System;
using System.Collections.Generic;
using System.Text;

namespace GTTServiceContract.ProjectImplementation
{
    public class Project
    {
        public string ID { get; set; }

        public string ProjectName { get; set; }
        public List<string> TaskList { get; set; } = new List<string>();
        public List<string> RoomList { get; set; } = new List<string>();

        public Project(string id, string projectName)
        {
            ID = id;
            ProjectName = projectName;
        }

   }
}
