namespace GTTClientBackend.Models
{
    public class ChatBoxMessage
    {
        public string Author { get; }
        public string Message { get; }
        internal ChatBoxMessage(string author, string message)
        {
            Author = author;
            Message = message;
        }
    }
}
