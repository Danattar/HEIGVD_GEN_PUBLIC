﻿using GTTClientBackend.Models;
using GTTServiceContract.Task;
using JKang.IpcServiceFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GTTClientBackend.Services
{
    public class TaskService
    {
        private BackgroundWorker _clientService;
        private readonly List<TaskBox> _taskBoxList = new List<TaskBox>();
        private IpcServiceClient<ITaskManager> _client;


        public TaskService()
        {
            ConnectToServer();
            ExposeClient();
        }
        private void ConnectToServer()
        {
            /*
            _client = new IpcServiceClientBuilder<ITaskManager>()
                .UseNamedPipe("pipeName")
                .Build();
                */
            _client = new IpcServiceClientBuilder<ITaskManager>()
   .UseNamedPipe("pipeName2")
   .Build();
            System.Net.IPAddress serverIP = IPAddress.Parse("192.168.0.234");

            /*            System.Net.IPAddress serverIP = IPAddress.Parse("192.168.0.248");
                        _client = new IpcServiceClientBuilder<IRoomManager>()
                            .UseTcp(serverIP, 45684)
                            .Build();
             */           //            192.168.0.248
        }
        private void ExposeClient()
        {
            _clientService = new BackgroundWorker();
            _clientService.DoWork += StartService;
            _clientService.RunWorkerCompleted += StopService;
            _clientService.WorkerSupportsCancellation = true;
            _clientService.RunWorkerAsync();
        }

        private void StartService(object sender, DoWorkEventArgs e)
        {
            while (!_clientService.CancellationPending)
            {
                System.Diagnostics.Trace.WriteLine("service running");
                Thread.Sleep(100);
            }

    
        }
        private void StopService(object sender, RunWorkerCompletedEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Client Service Stopped");
        }

        public async Task<TaskBox> GetNewTaskBoxAsync(string brief, string summary, string assignedUser)
        {
            ITaskItem taskItem;
            try
            {
                taskItem = await _client.InvokeAsync(x => x.AddTask(brief, summary, assignedUser));
            }
            catch (Exception e)
            {
                throw new Exception("An error occured while retrieving a new Task", e);
            }

            return AddTaskBox(taskItem);

            // return new ChatBox(10);
            // return AddChatBox(_chatboxManager.AddRoom());
        }
        public async Task<TaskBox> GetTaskBox(int id)
        {
            ITaskItem taskItem;
            try
            {
                taskItem = await _client.InvokeAsync(x => x.GetTask(id));
            }
            catch (Exception e)
            {
                throw new Exception("An error occured while retrieving a new Room", e);
            }

            return AddTaskBox(taskItem);
        }
        private TaskBox AddTaskBox(ITaskItem taskItem)
        {
            TaskBox taskBox = CreateTaskBox(taskItem);
            _taskBoxList.Add(taskBox);
            return taskBox;
        }

        #region Factory

        private TaskBox CreateTaskBox(ITaskItem taskItem) => new TaskBox(taskItem.ID, taskItem.Brief, taskItem.Summary, taskItem.AssignedUser);

        #endregion
    }
}
