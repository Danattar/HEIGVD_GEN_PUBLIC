using System.Xml.Serialization;

namespace GTTServiceContract.Room
{
    public interface IRoomMessage : IXmlSerializable
    {
        string Author { get; set; }
        string Message { get; set; }

    }
}
