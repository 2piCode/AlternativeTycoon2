using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class temp : MonoBehaviour
    {
        public delegate void SomeAction();
        public event SomeAction someAction;
        public static temp singleton { get; private set; }

        void Awake()
        {
            singleton = this;
        }

        void Start()
        {
        }

        void OnMouseDown()
        {
            Debug.Log("1");
            someAction?.Invoke();
        }
    }
}
