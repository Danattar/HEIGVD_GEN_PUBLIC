using GTTServiceContract.Task;
using GTTServiceContract.TaskImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public TaskManager()
        {
          /*  var d = new System.IO.DirectoryInfo(_programsDirectory);
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
            }*/
        }

        public TaskItem AddTask(string brief, string summary, string assignedUser)
        {
            TaskItem task = CreateTask(brief, summary, assignedUser);
            _taskList.Add(task);
            Console.WriteLine("Task added");
            /*
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
            }*/




            Console.WriteLine("Task Added : \nBrief : " + brief + "\nAssignee : " + assignedUser);
            return task;
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
            _users.Add(loginScreenUsername);
            Console.WriteLine("Logged in as : " + loginScreenUsername);
        }

        public List<string> GetAllUsers()
        {
            return _users;
        }


        #region Factory

        private TaskItem CreateTask(string brief, string summary, string assignedUser)
        {
            return new TaskItem(brief, summary, assignedUser);
        }


        #endregion
    }
}
