using Caliburn.Micro;

namespace GenProject.ViewModels
{
    public class DashboardViewModel : Screen
    {
        public Screen ChatBox1 { get; }
        public Screen ChatBox2 { get; }

        public DashboardViewModel()
        {
            ChatBox1 = new ChatBoxViewModel("Simon -> Frédéric", 1);
            ChatBox2 = new ChatBoxViewModel("Frédéric -> Simon", 1);
        }
    }
}