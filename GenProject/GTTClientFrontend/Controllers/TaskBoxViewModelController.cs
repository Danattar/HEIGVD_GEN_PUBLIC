using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using GTTClientBackend.Models;
using GTTClientFrontend.ViewModels;
using GTTClientBackend.Services;
using GTTServiceContract.Task;
using GTTServiceContract.TaskImplementation;

namespace GTTClientFrontend.Controllers
{
    public class TaskBoxViewModelController
    {
        private TaskService _taskService;

        public TaskBoxViewModelController(TaskService taskService)
        {
            _taskService = taskService;

        }
        public async Task<TaskBoxViewModel> GetTaskBoxAsync(string brief, string summary, string assignee,
            string reviewer, DateTime dueDate, TaskType taskSelectedTaskType)
        {
            TaskBoxViewModel taskBoxVM = null;
            try
            {
                taskBoxVM = await CreateTaskBoxViewModel(await _taskService.GetNewTaskBoxAsync(brief, summary, assignee, reviewer, dueDate, taskSelectedTaskType));
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
            return new TaskBoxViewModel(taskBox);
        }

        public void LoggedInAs(string loginScreenUsername)
        {
            _taskService.LoggedInAs(loginScreenUsername);
        }

        public async Task<List<string>> GetAllUsers()
        {
            return await _taskService.GetAllUsers();
        }

        public bool UpdateTask(TaskBoxViewModel selectedTask)
        {
            try
            {
                _taskService.AssignTask(selectedTask.TaskID, selectedTask.Assignee);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<TaskBoxViewModel>> GetTaskBoxListForUser(string username)
        {
            List<TaskBox> taskBoxList = await _taskService.GetTaskBoxListForUser(username);
            List<TaskBoxViewModel> taskBoxViewModelsList = new List<TaskBoxViewModel>();
            taskBoxList.ForEach(async taskBox => { taskBoxViewModelsList.Add(await CreateTaskBoxViewModel(taskBox)); });
            return taskBoxViewModelsList;
        }
    }
}