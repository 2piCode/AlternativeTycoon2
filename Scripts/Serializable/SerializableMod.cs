using System;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

namespace Game
{
    [Serializable]
    public class SerializableMod
    {
        public SerializableMod() { }

        [XmlElement("Name")]
        public string name { get; set; }

        [XmlElement("Genre")]
        public Genre genre { get; set; }

        [XmlElement("Country")]
        public Country country { get; set; }

        [XmlElement("Cost")]
        public double cost { get; set; }

        [XmlElement("Price")]
        public double price { get; set; }

        // [XmlElement("requirement")]
        // public event onRequirement requirement;

        // public delegate void onRequirement();

        public SerializableMod(Mod mod)
        {
            this.name = mod.name;
            this.genre = mod.genre;
            this.country = mod.country;
            this.cost = mod.cost;
            this.price = mod.price;
        }

        public static void SerializeXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<SerializableMod>));
            var a = new List<SerializableMod>();
            foreach (var item in GameManager.singleton.Mods)
                a.Add(new SerializableMod(item.Value));

            using (FileStream fs = new FileStream(Application.dataPath + "/Mods.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, a);
            }
        }

        public static List<SerializableMod> DeSerializeXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<SerializableMod>));

            using (FileStream fs = new FileStream(Application.dataPath + "/Mods.xml", FileMode.OpenOrCreate))
            {
                return serializer.Deserialize(fs) as List<SerializableMod>;
            }
        }
    }
}
