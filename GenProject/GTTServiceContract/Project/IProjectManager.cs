using System;
using System.Collections.Generic;
using System.Text;
using GTTServiceContract.ProjectImplementation;

namespace GTTServiceContract.Project
{
    public interface IProjectManager
    {
        ProjectImplementation.Project GetProject(string id);
        Dictionary<string, ProjectImplementation.Project> GetProjects();
        ProjectImplementation.Project AddProject(string projectID, string projectName);
        bool LinkTaskToProject(string taskID, string projectID);
        bool LinkRoomToProject(string roomID, string projectID);
    }
}
