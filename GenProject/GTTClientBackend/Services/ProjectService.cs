﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GTTClientBackend.Models;
using GTTServiceContract.Project;
using GTTServiceContract.ProjectImplementation;
using JKang.IpcServiceFramework;

namespace GTTClientBackend.Services
{
    public class ProjectService
    {
        private BackgroundWorker _clientService;
        private readonly List<string> _taskBoxList = new List<string>();
        private IpcServiceClient<IProjectManager> _client;

        public ProjectService()
        {
            ConnectToServer();
        }

        private void ConnectToServer()
        {
            /*
            _client = new IpcServiceClientBuilder<ITaskManager>()
                .UseNamedPipe("pipeName")
                .Build();
                */
            _client = new IpcServiceClientBuilder<IProjectManager>()
               .UseNamedPipe("pipeName3")
               .Build();
//            System.Net.IPAddress serverIP = IPAddress.Parse("192.168.0.234");

            /*            System.Net.IPAddress serverIP = IPAddress.Parse("192.168.0.248");
                        _client = new IpcServiceClientBuilder<IRoomManager>()
                            .UseTcp(serverIP, 45684)
                            .Build();
             */           //            192.168.0.248
        }

        public async Task<List<string>> GetProjectsId()
        {
            List<string> projectList;
            try
            {
                projectList = await _client.InvokeAsync(x => x.GetProjects());
            }
            catch (Exception e)
            {
                throw new Exception("An error occured while retrieving a new Task", e);
            }

            return projectList;
        }

        public async Task<bool> LinkTaskToProject(string taskId, string projectId)
        {
            return await _client.InvokeAsync(x => x.LinkTaskToProject(taskId, projectId));
        }

        public async Task<string> GetProjectByTask(string taskId)
        {
            return await _client.InvokeAsync(x => x.GetProjectByTask(taskId));
        }

        public async Task<bool> LinkRoomToProject(string roomId, string projectId)
        {
            return await _client.InvokeAsync(x => x.LinkRoomToProject(roomId, projectId));
        }

        public void CreateProjectIfNotExists(string projectId, string projectName)
        {
            _client.InvokeAsync(x => x.AddProject(projectId, projectName));
        }
    }
}
