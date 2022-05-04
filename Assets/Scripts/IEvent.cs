using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class IEvent : MonoBehaviour
    {
        void Start()
        {
            dependentEvents = new List<Tuple<string, double>>();
            consequences = new List<Action>();


        }

        public IEvent(string id, string name, string description, 
            List<Tuple<string, double>> dependentEvents, List<Action> consequences)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.dependentEvents = dependentEvents;
            this.consequences = consequences;
        }
        
        public readonly string name;
        public readonly string description;

        //private void changeDependentEventsChance()
        //{
        //    Debug.Log("change");
        //    foreach (var elem in dependentEvents)
        //    {
        //        elem.chance += elem.Item2;
        //    }
        //}

        private void raiseConsequences()
        {
            Debug.Log("raise");
            foreach (var consequence in consequences)
            {
                consequence();
            }
        }
        

        private List<Tuple<string, double>> dependentEvents;
        private List<Action> consequences; //последствия как ивенты
        private readonly string id;
    }
}   