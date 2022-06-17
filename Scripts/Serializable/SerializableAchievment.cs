using System;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

namespace Game 
{
    [Serializable]
    public class SerializableAchievment
    {
        public SerializableAchievment() { }

        [XmlElement("id")]
        public string id { get; set; }

        [XmlElement("name")]
        public string name { get; set; }

        [XmlElement("description")]
        public string description { get; set; }

        [XmlElement("roflDescription")]
        public string roflDescription { get; set; }

        // [XmlElement("requirement")]
        // public event onRequirement requirement;
        
        // public delegate void onRequirement();

        public SerializableAchievment(Achievment achievment)
        {
            this.id = achievment.id;
            this.name = achievment.name;
            this.description = achievment.description;
            this.roflDescription = achievment.roflDescription;
        }

        public static void SerializeXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<SerializableAchievment>));
            var a = new List<SerializableAchievment>();
            foreach (var item in GameManager.singleton.Achievments)
                a.Add(new SerializableAchievment(item.Value));

            using (FileStream fs = new FileStream(Application.dataPath + "/Achievments.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, a);
            }
        }

        public static List<SerializableAchievment> DeSerializeXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<SerializableAchievment>));

            using (FileStream fs = new FileStream(Application.dataPath + "/Achievments.xml", FileMode.OpenOrCreate))
            {
                return serializer.Deserialize(fs) as List<SerializableAchievment>;
            }
        }
    }
}
