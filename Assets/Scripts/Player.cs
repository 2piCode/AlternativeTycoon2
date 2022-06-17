using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game 
{
    public class Player
    {
        public Player()
        {
            Money = 1000; // start Money
        }


        public delegate void OnAddMoney();
        public event OnAddMoney onAddMoney;
        public double Money;
        public List<IFinance> assets;

        public void AddMoney(double amount)
        {
            Money += amount;
            onAddMoney?.Invoke();
        }
    }
}
