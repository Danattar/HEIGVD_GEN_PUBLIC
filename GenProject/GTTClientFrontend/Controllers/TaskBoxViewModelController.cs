using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using GTTClientBackend.Models;
using GTTClientFrontend.ViewModels;
using GTTClientBackend.Services;

namespace GTTClientFrontend.Controllers
{
    public class TaskBoxViewModelController
    {
        private TaskService _taskService;

        public TaskBoxViewModelController(TaskService taskService)
        {
            _taskService = taskService;

        }
        public async Task<TaskBoxViewModel> GetTaskBoxAsync(string brief, string summary, string assignee)
        {
            TaskBoxViewModel taskBoxVM = null;
            try
            {
                taskBoxVM = await CreateTaskBoxViewModel(await _taskService.GetNewTaskBoxAsync(brief, summary, assignee));
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show("An error occured while retrieving a new ChatBox "
                                               + Environment.NewLine + "Message : " + e.Message
                                               + Environment.NewLine + "Stack Trace : " + e.StackTrace
                                               + Environment.NewLine + "Inner Exception : " + e.InnerException
                );
            }
            return taskBoxVM;
        }

        private async Task<TaskBoxViewModel> CreateTaskBoxViewModel(TaskBox taskBox)
        {
            var a = new TaskBoxViewModel(taskBox);
//            a.Users.AddRange(await _taskService.GetAllUsers());
            return a;
        }

        public void LoggedInAs(string loginScreenUsername)
        {
            _taskService.LoggedInAs(loginScreenUsername);
        }

        public async Task<List<string>> GetAllUsers()
        {
            return await _taskService.GetAllUsers();
        }
    }
}