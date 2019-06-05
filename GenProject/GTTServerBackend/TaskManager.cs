using GTTServiceContract.Task;
using GTTServiceContract.TaskImplementation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
//TODO 
namespace GTTServerBackend
{
    public class TaskManager : ITaskManager
    {
        private static readonly List<TaskItem> _taskList = new List<TaskItem>();
        private static List<string> _users = new List<String>();

        public bool IsConnected()
        {
            return true;
        }
        //todo refacto
        public static string ProgramsDirectory
        {
            get
            {
                if (String.IsNullOrEmpty(_programsDirectory))
                {
                    //todo
                    _programsDirectory = System.IO.Path.Combine(SmartVisionDirectory, "Programs");
                    if (!System.IO.Directory.Exists(_programsDirectory))
                    {
                        System.IO.Directory.CreateDirectory(_programsDirectory);
                    }
                }
                return _programsDirectory;
            }
        }
        private static string _programsDirectory;
        public static string SmartVisionDirectory
        {
            get
            {
                if (String.IsNullOrEmpty(_smartVisionDirectory))
                {
                    _smartVisionDirectory = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SBC", "GTT");
                    if (!System.IO.Directory.Exists(_smartVisionDirectory))
                    {
                        System.IO.Directory.CreateDirectory(_smartVisionDirectory);
                    }
                }
                return _smartVisionDirectory;
            }
        }
        private static string _smartVisionDirectory;
        private static bool _isDeserialized = false;

        public TaskManager()
        {
            if (!_isDeserialized) { }
    //            Deserialize();
            Console.WriteLine("New instance of TaskManager");
        }


        private void Deserialize()
        {
            var d = new System.IO.DirectoryInfo(ProgramsDirectory);
            System.IO.FileInfo[] files = d.GetFiles("*.sbc");
            foreach (System.IO.FileInfo file in files)
            {
                var str = _programsDirectory + @"\" + file.Name;

                using (System.Xml.XmlReader reader = System.Xml.XmlReader.Create(str))
                {
                    try
                    {
                        while (reader.Read())
                        {
                            switch (reader.NodeType)
                            {
                                case System.Xml.XmlNodeType.Element:
                                    if (reader.Name == "TaskItem")
                                    {
                                        TaskItem document = new TaskItem();
                                        document.ReadXml(reader);
                                        _taskList.Add(document);
                                    }
                                    break;
                                case System.Xml.XmlNodeType.EndElement:
                                    if (reader.Name == "TaskItem")
                                    {
                                        return;
                                    }
                                    break;
                            }
                        }
                    }
                    finally
                    {
                        reader.Close();
                    }

                }
            }

            File.WriteAllText(@"C:\temp\logfile.txt", _taskList.Count.ToString());
            _isDeserialized = true;
        }

        public TaskItem AddTask(string brief, string summary, string assignedUser, string reviewer, 
                                DateTime dueDate, TaskType taskType)
        {
            TaskItem task = CreateTask(brief, summary, assignedUser, reviewer, dueDate, taskType);
            _taskList.Add(task);
            Console.WriteLine("Task added");
//            Serialize();
            

            Console.WriteLine("Task Added : \nBrief : " + brief + "\nAssignee : " + assignedUser);
            return task;
        }

        private void Serialize()
        {
            var settings = new System.Xml.XmlWriterSettings { Indent = true };
            foreach (TaskItem document in _taskList)
            {
                using (System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(_programsDirectory + @"\" + "test" + ".sbc", settings))
                {
                    try
                    {
                        document.WriteXml(writer);
                    }
                    finally
                    {
                        writer.Close();
                    }
                }
            }
        }

        public TaskItem GetTask(int taskID)
        {
            return _taskList.Where(x => x.ID == taskID).FirstOrDefault();
        }
        public TaskItem[] GetTaskAssignedToUser(string user)
        {
            return _taskList.Where(x => x.Assignee == user).ToArray();
        }
        public void DeleteTask(int taskId)
        {
            try
            {
                _taskList.Remove(_taskList.Where(x => x.ID == taskId).First());
            }
            catch
            {
                Console.WriteLine("Task " + taskId + " doesn't exist. It can't be removed");
            }
        }
        public void AssignTaskToUser(int taskId, string newUser)
        {
            try
            {
                _taskList.Where(x => x.ID == taskId).First().Assignee = newUser;

            }
            catch
            {
                Console.WriteLine("Task " + taskId + " doesn't exist. It can't be updated.");
            }
        }

        public void LoggedInAs(string loginScreenUsername)
        {
            if(_users.Where(x=> x == loginScreenUsername).Count() == 0)
                _users.Add(loginScreenUsername);
            Console.WriteLine("Logged in as : " + loginScreenUsername);
        }

        public List<string> GetAllUsers()
        {
            return _users;
        }


        #region Factory

        private TaskItem CreateTask(string brief, string summary, string assignedUser, string reviewer, DateTime dueDate, TaskType taskType)
        {
            return new TaskItem(brief, summary, assignedUser, reviewer, dueDate, taskType);
        }


        #endregion
    }
}
