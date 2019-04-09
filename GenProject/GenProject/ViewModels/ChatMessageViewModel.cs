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

        public string Author { get; }
        public string Message { get; } 

    }
}