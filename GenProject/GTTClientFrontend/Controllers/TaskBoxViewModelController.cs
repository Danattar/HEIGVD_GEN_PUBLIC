using System;
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
                taskBoxVM = CreateTaskBoxViewModel(await _taskService.GetNewTaskBoxAsync(brief, summary, assignee));
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

        private TaskBoxViewModel CreateTaskBoxViewModel(TaskBox taskBox)
        {
            return new TaskBoxViewModel(taskBox);
        }
    }
}