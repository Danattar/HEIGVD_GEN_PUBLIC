using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTTServiceContract.ProjectImplementation;

namespace GTTServerBackend
{
    public class ProjectManager
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
        public Dictionary<string, Project> GetProjects()
        {
            return _projectList;
        }
        public Project AddProject(string projectID, string projectName)
        {
            bool result = _projectList.TryGetValue(projectID, out Project p);
            if (!result) 
                p = CreateProject(projectID, projectName);
            return p;
        }
         public bool LinkTaskToProject(string taskID, string projectID)
        {
            bool result = _projectList.TryGetValue(projectID, out Project p);
            if (result)
            {
                p.TaskList.Add(taskID);
            }
            return result;
        }

        public bool LinkRoomToProject(string roomID, string projectID)
        {
            bool result = _projectList.TryGetValue(projectID, out Project p);
            if (result)
            {
                p.RoomList.Add(roomID);
            }
            return result;            
        }

        #region Factories
        private Project CreateProject(in string id, string projectName)
        {
            return new Project(id, projectName);
        }
        #endregion


   }
}
