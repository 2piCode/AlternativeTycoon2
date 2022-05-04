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
        public Dictionary<string, IEvent> eventsOnLocation { get; private set; }
        private GameObject obj;

        void Awake()
        {
            singleton = this;
            eventsOnLocation = new Dictionary<string, IEvent>();
            currentDate = new GameDateTime();
        }

        void Start()
        {
            temp.singleton.someAction += FinishDay;
            Debug.Log(currentDate.ToString());
            
            eventsOnLocation["1"] = new IEvent("1", "FirstEvent", "First Description",
                new List<Tuple<string, double>>(), new List<Action>());
            eventsOnLocation["2"] = new IEvent("2", "SecondEvent", "Second Description",
                new List<Tuple<string, double>>(), new List<Action>());

            obj
            Instantiate(obj);
        }

        void Update()
        {

        }

        public void FinishDay()
        {
            currentDate.AddDays(1);
            onFinishDay?.Invoke();
            Debug.Log("123");
        }
    }
    
}
