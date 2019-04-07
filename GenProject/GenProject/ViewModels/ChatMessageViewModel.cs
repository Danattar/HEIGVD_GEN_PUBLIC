using Caliburn.Micro;

namespace GenProject.ViewModels
{
    public class ChatMessageViewModel : Screen
    {

        public ChatMessageViewModel(string author, string message)
        {
            Author = author;
            Message = message;
        }
        public ChatMessageViewModel()
        {

        }

        public string Author { get; } = "Simon";
        public string Message { get; } = "test";

    }
}