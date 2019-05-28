using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTTServiceContract.Project;
using GTTServiceContract.ProjectImplementation;

namespace GTTServerBackend
{
    public class ProjectManager : IProjectManager
    {
        private Dictionary<string, Project> _projectList = new Dictionary<string, Project>();

        public ProjectManager()
        {
            Project project0 = CreateProject("0", "Default Project");
            Project project1 = CreateProject("GEN", "School-GEN");
            Project project2 = CreateProject("POO2", "School-POO2");
            Project project3 = CreateProject("PRO", "School-PRO");
            Project project4 = CreateProject("ARO2", "School-ARO2");
            Project project5 = CreateProject("SER", "School-SER");
            _projectList.Add(project0.ID, project0);
            _projectList.Add(project1.ID, project1);
            _projectList.Add(project2.ID, project2);
            _projectList.Add(project3.ID, project3);
            _projectList.Add(project4.ID, project4);
            _projectList.Add(project5.ID, project5);
//            Console.WriteLine("ProjectManagerConnected");
        }

        public Project GetProject(string id)
        {
            bool r = _projectList.TryGetValue(id, out Project project);
            if (!r)
            {
                _projectList.TryGetValue("0", out project);
            }
            return project;
        }
        public List<string> GetProjects()
        {
            return _projectList.Keys.ToList();
        }
        public Project AddProject(string projectID, string projectName)
        {
            bool result = _projectList.TryGetValue(projectID, out Project p);
            if (!result)
            {
                p = CreateProject(projectID, projectName);
                _projectList.Add(projectID,p);
                Console.WriteLine(projectID + " created");
            }

            return p;
        }
        public bool LinkTaskToProject(string taskID, string projectID)
        {
            bool result = _projectList.TryGetValue(projectID, out Project p);
            if (result)
            {
                p.TaskList.Add(taskID);
                Console.WriteLine("Task: " + taskID + " was linked to Project: " + projectID);
            }
            return result;
        }

        public bool LinkRoomToProject(string roomID, string projectID)
        {
            bool result = _projectList.TryGetValue(projectID, out Project p);
            if (result)
            {
                p.RoomList.Add(roomID);
                Console.WriteLine("Room: " + roomID + " was linked to Project: " + projectID);
            }
            return result;            
        }

        public string GetProjectByTask(string taskId)
        {
            foreach (var p in _projectList.Values)
            {
                if (p.TaskList.Contains(taskId)) return p.ID;
            }

            return "no project is linked for this task";
        }

        #region Factories
        private Project CreateProject(string id, string projectName)
        {
            return new Project(id, projectName);
        }
        #endregion


   }
}
