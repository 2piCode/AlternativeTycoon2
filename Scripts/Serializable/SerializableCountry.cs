using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

namespace Game
{
    [Serializable]
	public class SerializableCountry
	{	
        [XmlElement("Name")]
		public string Name;
        [XmlElement("Population")]
		public int Population;
        [XmlElement("RateForGenre")]
		public List<(Genre, double)> rateForGenre;

        public SerializableCountry(){}

		public SerializableCountry(Country country)
		{
            this.Name = country.Name;
            this.Population = country.Population;
            this.rateForGenre = country.rateForGenre;
		}

		public static void SerializeXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<SerializableCountry>));
            var a = new List<SerializableCountry>();
            foreach (var item in GameManager.singleton.Countries)
                a.Add(new SerializableCountry(item.Value));

            using (FileStream fs = new FileStream(Application.dataPath + "/Countries.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, a);
            }
        }

        public static List<SerializableCountry> DeSerializeXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<SerializableCountry>));

            using (FileStream fs = new FileStream(Application.dataPath + "/Countries.xml", FileMode.OpenOrCreate))
            {
                return serializer.Deserialize(fs) as List<SerializableCountry>;
            }
        }

	}
}