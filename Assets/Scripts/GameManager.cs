using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public delegate void OnFinishDay();
        public event OnFinishDay onFinishDay;
        public static GameManager singleton { get; private set; }
        public GameDateTime currentDate { get; private set; }
        public Dictionary<string, IEvent> allEvents { get; set; }
        public List<IEvent> eventsOnDay { get; private set; }

        void Awake()
        {
            singleton = this;
            eventsOnDay = new List<IEvent>();
            allEvents = new Dictionary<string, IEvent>();
            currentDate = new GameDateTime();
        }

        void Start()
        {

            temp.singleton.someAction += FinishDay;
            #region generating allEvents
/*            List<string> cons = new List<string>();
            List<(string, double)> dep = new List<(string, double)>();
            dep.Add(("2", 3));
            dep.Add(("3", 4));
            cons.Add("123");
            cons.Add("1234");
            allEvents["1"] = new IEvent("1", "First Event", "First Description", 30,
                dep, cons);
            allEvents["2"] = new IEvent("2", "Second Event", "Second Description", 20,
                dep, cons);
            allEvents["3"] = new IEvent("3", "Third Event", "Third Description", 10,
                dep, cons);
            allEvents["4"] = new IEvent("4", "Fourth Event", "Fourth Description", 70,
                dep, cons);
            allEvents["5"] = new IEvent("5", "Fifth Event", "Fifth Description", 60,
                dep, cons);
            allEvents["6"] = new IEvent("6", "Sixth Event", "Sixth Description", 50,
                dep, cons);*/
            #endregion
            foreach (var item in SerializableIEvent.DeSerializeXml())
            {
                allEvents[item.id] = new IEvent(item);
            }

            #region writeInNote

            #endregion
            setEventsOnDay(0);
            foreach (var item in eventsOnDay)
            {
                Debug.Log(item.id);
            }
        }

        public void FinishDay()
        {
            currentDate.AddDays(1);
            setEventsOnDay(1);
            onFinishDay?.Invoke();
        }

        private void setEventsOnDay(int numberOfRandomEvents = 1)
        {
            eventsOnDay.Clear();
            foreach (var item in allEvents.Values)
            {
                if (item.chance == 100)
                {
                    item.IncreaseChance(-100);
                    eventsOnDay.Add(item);
                }
            }

            for (int i = 0; i < numberOfRandomEvents; i++)
            {
                IEvent ev = IEvent.getRandomEvent();
                ev.IncreaseChance(-100);
                eventsOnDay.Add(ev);
            }
        }
    }
    
}
