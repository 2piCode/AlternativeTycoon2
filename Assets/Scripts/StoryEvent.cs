using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class StoryEvent : IEvent
    {
        StoryEvent(string id, string name, string description, List<Tuple<string, double>> dependentEvents, List<Action> consequences) 
            : base(id, name, description, dependentEvents, consequences){}
    }
}

