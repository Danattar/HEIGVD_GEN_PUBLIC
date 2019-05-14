using GTTServiceContract.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace GTTServiceContract.RoomImplementation
{
    public class Room  : IRoom, IXmlSerializable
    {
        private static int _nextID = 1;
        public int ID { get; set; }
        public string Name { get; set; }
        public List<IRoomMessage> RoomMessageList { get; } = new List<IRoomMessage>();

        public Room()
        {
            ID = _nextID++;
//            AddMessage(new RoomMessage("GTT", "Welcome to your new Room"));
        }

        public void AddMessage(IRoomMessage chatboxMessage)
        {
            RoomMessageList.Add((RoomMessage)chatboxMessage);
            NewMessage?.Invoke(chatboxMessage);
        }

        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            ID = Int32.Parse(reader.GetAttribute("ID"));
            Name = reader.GetAttribute("Name");
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:

                        switch (reader.Name)
                        {
                            case "RoomMessage":
                                var roomMessage = new RoomMessage();
                                roomMessage.ReadXml(reader);
                                RoomMessageList.Add(roomMessage);
                                break;
                        }
                        break;
                }
            }
        }


        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Room");
            writer.WriteAttributeString("Id", ID.ToString());
            writer.WriteAttributeString("Name", Name);
            foreach (IRoomMessage message in RoomMessageList)
            {
                message.WriteXml(writer);
            }
            writer.WriteFullEndElement();

        }

        public event Action<IRoomMessage> NewMessage;
    }
}
