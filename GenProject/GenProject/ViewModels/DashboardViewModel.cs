using Caliburn.Micro;
using GenProject.Services;
using GenProject.ViewModelFactory;

namespace GenProject.ViewModels
{
    public class DashboardViewModel : Screen
    {
        public ChatBoxViewModel ChatBox1 { get; }
        public ChatBoxViewModel ChatBox2 { get; }

       // private readonly ChatboxViewModelFactory _chatboxVMFactory;

        public DashboardViewModel(Service service, ChatboxService chatboxService)
        {
            ChatBox1 = chatboxService.CreateChatbox();
            ChatBox2 = chatboxService.GetChatboxViewModel(ChatBox1.ChatSessionID);

            // ChatBox1 = new ChatBoxViewModel("Simon -> Frédéric", 1, service);
            //ChatBox1 = chatBoxVMFactory.CreateChatBoxViewModel();
    //        ChatBox2 = new ChatBoxViewModel("Frédéric -> Simon", 1, service);
    //        service.MessageSent += (ChatBox1 as ChatBoxViewModel).MessageListenerHandler;
   //         service.MessageSent += (ChatBox2 as ChatBoxViewModel).MessageListenerHandler;

          //  _chatBoxVMFactory = chatBoxVMFactory;
        }
    }
}