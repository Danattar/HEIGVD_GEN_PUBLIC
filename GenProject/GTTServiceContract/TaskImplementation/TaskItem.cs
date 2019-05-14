using GTTServiceContract.Task;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace GTTServiceContract.TaskImplementation
{
    public class TaskItem : ITaskItem, IXmlSerializable
    {
        private static int _nextID = 1;
        public int ID { get; private set; }
        public string Brief { get; set; }
        public string Summary { get; set; }
        public string Assignee { get; set; }

        public TaskItem()
        {
        }
        public TaskItem(string brief, string summary, string assignee)
        {
            ID = _nextID++;
            Brief = brief;
            Summary = summary;
            Assignee = assignee;
        }
        [JsonConstructor]
        public TaskItem(int id, string brief, string summary, string assignee)  
        {
            ID = id;
            Brief = brief;
            Summary = summary;
            Assignee = assignee;
        }

        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            ID = Int32.Parse(reader.GetAttribute("ID"));
            Brief = reader.GetAttribute("Brief");
            Summary = reader.GetAttribute("Summary");
            Assignee = reader.GetAttribute("Assignee");
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("TaskItem");
            writer.WriteAttributeString("ID", ID.ToString());
            writer.WriteAttributeString("Brief", Brief);
            writer.WriteAttributeString("Summary", Summary);
            writer.WriteAttributeString("Assignee", Assignee);
            writer.WriteFullEndElement();
        }
    }
}
