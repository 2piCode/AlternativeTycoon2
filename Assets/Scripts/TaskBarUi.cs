using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class TaskBarUi : MonoBehaviour
    {
        public void PrintTasks()
        {
            GetComponent<Text>().text = $"{GameManager.singleton.eventsOnLocation["1"].name}";
            GetComponent<Text>().text = $"{GameManager.singleton.eventsOnLocation["2"].name}";
        }

        public void Start()
        {
            GameManager.singleton.onFinishDay += PrintTasks;
        }
    }
}
