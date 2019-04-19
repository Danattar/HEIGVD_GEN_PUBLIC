using Caliburn.Micro;
using GenProject.Controllers;
using GenProjectClientBackend.Services;

namespace GenProjectClientInterface.ViewModels
{
    public class DashboardViewModel : Screen
    {
        public ChatBoxViewModel ChatBox1 { get; }
        public ChatBoxViewModel ChatBox2 { get; }

        private readonly ChatBoxViewModelController _chatBoxController;
        public DashboardViewModel(ChatBoxViewModelController chatBoxCtl)
        {
            _chatBoxController = chatBoxCtl;
            ChatBox1 = chatBoxCtl.GetChatBox();
            ChatBox2 = chatBoxCtl.GetChatBox(ChatBox1.RoomID);
        }
    }
}