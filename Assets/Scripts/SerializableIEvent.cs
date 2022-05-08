using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

namespace Game 
{
    [Serializable]
    public class SerializableIEvent
    {
        public SerializableIEvent() { }

        [XmlElement("id")]
        public string id { get; set; }

        [XmlElement("name")]
        public string name { get; set; }

        [XmlElement("description")]
        public string description { get; set; }

        [XmlElement("chance")]
        public double chance { get; set; }

        [XmlElement("dependentEvents")]
        public List<(string, double)> dependentEvents { get; set; }

        [XmlElement("consequences")]
        public List<string> consequences { get; set; }
        
        public SerializableIEvent(IEvent ev)
        {
            this.id = ev.id;
            this.name = ev.name;
            this.description = ev.description;
            this.chance = ev.chance;
            this.dependentEvents = ev.dependentEvents;
            this.consequences = ev.consequences;
        }

        public static void SerializeXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<SerializableIEvent>));
            var a = new List<SerializableIEvent>();
            foreach (var item in GameManager.singleton.allEvents)
                a.Add(new SerializableIEvent(item.Value));

            using (FileStream fs = new FileStream(Application.dataPath + "/Events.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, a);
            }
        }

        public static List<SerializableIEvent> DeSerializeXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<SerializableIEvent>));

            using (FileStream fs = new FileStream(Application.dataPath + "/Events.xml", FileMode.OpenOrCreate))
            {
                return serializer.Deserialize(fs) as List<SerializableIEvent>;
            }
        }
    }
}
