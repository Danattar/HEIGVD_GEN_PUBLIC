using System;
using System.Collections.Generic;
using System.Text;

namespace GTTServiceContract.Task
{
    public interface ITaskItem
    {
        int ID { get; }
        string Brief { get; set; }
        string Summary { get; set; }
        string AssignedUser { get; set; }
    }
}
