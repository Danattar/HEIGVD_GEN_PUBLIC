using Caliburn.Micro;

namespace GenProject.ViewModels
{
    public class DashboardViewModel : Screen
    {
        public Screen ChatBox1 { get; }
        public Screen ChatBox2 { get; }

        public DashboardViewModel(Service service)
        {
            ChatBox1 = new ChatBoxViewModel("Simon -> Frédéric", 1, service);
            ChatBox2 = new ChatBoxViewModel("Frédéric -> Simon", 1, service);
            service.MessageSent += (ChatBox1 as ChatBoxViewModel).MessageListenerHandler;
            service.MessageSent += (ChatBox2 as ChatBoxViewModel).MessageListenerHandler;
        }
    }
}