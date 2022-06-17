using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

namespace Game
{
    public class Achievment
    {
        public Achievment() { }
        public Achievment (string id, string name, string description, string roflDescription)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.roflDescription = roflDescription;
        }

        public event onRequirement requirement;
        public delegate void onRequirement();

        public Achievment (SerializableAchievment serializableAchievment) :
            this (serializableAchievment.id, serializableAchievment.name, serializableAchievment.description, 
               serializableAchievment.roflDescription) { }

        public readonly string name;
        public readonly string description;
        public readonly string roflDescription;
        public readonly string id; 

        public void PassAchievment()
        {
            requirement -= PassAchievment;
        }
    }
}   