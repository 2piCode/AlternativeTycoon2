using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

namespace Game
{
    public class IEvent
    {
        public IEvent() { }
        public IEvent(string id, string name, string description, double chance,
            List<(string, double)> dependentEvents, List<string> consequences)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.chance = chance;
            this.dependentEvents = dependentEvents;
            this.consequences = consequences;
        }

        public IEvent(SerializableIEvent serializableIEvent) : this
               (serializableIEvent.id, serializableIEvent.name, serializableIEvent.description,
                serializableIEvent.chance, serializableIEvent.dependentEvents, serializableIEvent.consequences) { }

        public readonly string name;
        public readonly string description;
        public readonly string id;
        public double chance { get; private set; }
        public List<(string, double)> dependentEvents { get; private set; }
        public List<string> consequences { get; private set; } //последствия как id ивентов
        public void IncreaseChance(double percantage)
        {
            chance += percantage;
            if (chance < 0)
                chance = 0;
            if (chance > 100)
                chance = 100;
        }

        private void changeDependentEventsChance()
        {
            Debug.Log("change");
            foreach (var elem in dependentEvents)
            {
                GameManager.singleton.allEvents[elem.Item1].IncreaseChance(elem.Item2);
            }
        }

        private void raiseConsequences()
        {
            foreach (var consequence in consequences)
            {
                Debug.Log(consequence);
            }
        }

        public static IEvent getRandomEvent()
        {
            double chance = getRandomChance();

            IEvent eventWithClosestChance = GameManager.singleton.allEvents.Values.FirstOrDefault();
            foreach (var item in GameManager.singleton.allEvents.Values)
            {
                if (Math.Abs(eventWithClosestChance.chance - chance) > Math.Abs(item.chance - chance))
                {
                    eventWithClosestChance = item;
                }
            }
            return eventWithClosestChance;
        }

        private static double getRandomChance()
        {
            System.Random random = new System.Random();
            int[] limits = new int[10] { 100, 200, 1000, 3700, 10100, 22600, 44200, 78500, 129700, 202600 };
            int randomInt = random.Next(limits[0], limits[9]);
            for (int i = 0; i < 9; i++)
            {
                if (randomInt >= limits[i] && randomInt <= limits[i + 1])
                    return (i + 1) * 10 + (double)(random.Next(0, 100) / 10);
            }
            return 0;
        }
    }
}   