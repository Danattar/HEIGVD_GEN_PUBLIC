﻿using GTTServiceContract.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace GTTServiceContract.RoomImplementation
{
    [Serializable]
    public class RoomMessage : IRoomMessage
    {
        public string Author { get; private set; }
        public string Message { get; private set; }
        public RoomMessage()
        {

        }
        public RoomMessage(string author, string message)
        {
            Author = author;
            Message = message;
        }

        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            Author = reader.GetAttribute("Author");
            Message = reader.GetAttribute("Message");
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("RoomMessage");
            writer.WriteAttributeString("Author", Author);
            writer.WriteAttributeString("Message", Message);
            writer.WriteFullEndElement();
        }
    }
}
