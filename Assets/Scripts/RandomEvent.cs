using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class RandomEvent : IEvent
    {
        protected internal double chance;
        public void IncreaseChance(double percantage)
        {
            chance += percantage;
            if (chance < 0)
                chance = 0;
            if (chance > 100)
                chance = 100;
        }
        RandomEvent(string id, string name, string description, List<Tuple<string, double>> dependentEvents, List<Action> consequences)
            : base(id, name, description, dependentEvents, consequences) { }
    }
}
