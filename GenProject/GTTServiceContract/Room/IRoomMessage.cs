using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace GTTServiceContract.Room
{
    public interface IRoomMessage : IXmlSerializable
    {
        string Author { get; }
        string Message { get; }

    }
}
