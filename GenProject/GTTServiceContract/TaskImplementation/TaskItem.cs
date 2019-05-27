using GTTServiceContract.Task;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        public string Reviewer { get; set; }
        public DateTime DueDate { get; set; }
        public TaskType TaskType { get; set; }

        public TaskItem()
        {
        }
        public TaskItem(string brief, string summary, string assignee, string reviewer, DateTime dueDate, TaskType taskType)
        {
            ID = _nextID++;
            Brief = brief;
            Summary = summary;
            Assignee = assignee;
            Reviewer = reviewer;
            DueDate = dueDate;
            TaskType = taskType;
        }
        [JsonConstructor]
        public TaskItem(int id, string brief, string summary, string assignee, string reviewer, DateTime dueDate, TaskType taskType)
        {
            ID = id;
            Brief = brief;
            Summary = summary;
            Assignee = assignee;
            Reviewer = reviewer;
            DueDate = dueDate;
            TaskType = taskType;
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
            writer.WriteAttributeString("Reviewer", Reviewer);
            writer.WriteAttributeString("DueDate", DueDate.ToString(CultureInfo.InvariantCulture)); //TODO serialize correctly to enable deserialize
            writer.WriteAttributeString("TaskType", TaskType.ToString());
            writer.WriteFullEndElement();
        }
    }
}
