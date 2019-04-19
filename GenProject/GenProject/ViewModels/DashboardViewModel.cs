using Caliburn.Micro;
using GenProject.Controllers;
using GenProjectClientBackend.Services;

namespace GenProjectClientInterface.ViewModels
{
    public class DashboardViewModel : Screen
    {
        public ChatBoxViewModel ChatBox1 { get; }
        public ChatBoxViewModel ChatBox2 { get; }

        // private readonly ChatboxViewModelFactory _chatboxVMFactory;

        private readonly ChatBoxViewModelController _chatBoxController;
        public DashboardViewModel(ChatBoxViewModelController chatBoxCtl)
        {
            _chatBoxController = chatBoxCtl;
            ChatBox1 = chatBoxCtl.GetChatBox();
            ChatBox2 = chatBoxCtl.GetChatBox(ChatBox1.RoomID);


      //      ChatBox1 = chatboxService.CreateChatbox();
      //      ChatBox2 = chatboxService.GetChatboxViewModel(ChatBox1.ChatSessionID);

            // ChatBox1 = new ChatBoxViewModel("Simon -> Frédéric", 1, service);
            //ChatBox1 = chatBoxVMFactory.CreateChatBoxViewModel();
    //        ChatBox2 = new ChatBoxViewModel("Frédéric -> Simon", 1, service);
    //        service.MessageSent += (ChatBox1 as ChatBoxViewModel).MessageListenerHandler;
   //         service.MessageSent += (ChatBox2 as ChatBoxViewModel).MessageListenerHandler;

          //  _chatBoxVMFactory = chatBoxVMFactory;
        }
    }
}