using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game
{
    public class Deposit : IBankFinance
    {
        public Deposit(double cost, double percent, int periodInMonths, int periodOfPaymentInMonths = 1) : 
            base(cost, percent, periodInMonths, periodOfPaymentInMonths)
        {
            
        }

        public override void Buy(double amount)
        {
            GameManager.singleton.onFinishDay += MakePayment;
            GameManager.singleton.player.AddMoney(-amount);
            OnPayment(-amount);
        }

        public override void Sell(double amount)
        {
            Debug.Log("я продался");
            OnPayment(amount);
            GameManager.singleton.player.AddMoney(amount);
            GameManager.singleton.onFinishDay -= MakePayment;
        }

        public override void MakePayment()
        {
            if (GameManager.singleton.currentDate - NextPaymentDate >= 0) 
            {
                currentCost += monthPayment;
                OnPayment(monthPayment);
                NextPaymentDate = NextPaymentDate.AddMonths(periodOfPaymentInMonths);
            }
            Debug.Log(currentCost);
            if (GameManager.singleton.currentDate - EndDate >= 0)
                Sell(currentCost);
        }

        // тут надо разобраться с пробелами
        public override double monthPayment => 
            Math.Round(
                purchaseCost / GameDateTime.GetMonthsInPeriod(StartDate, EndDate), 1);

        protected override void OnPayment(double cost)
        {
            base.OnPayment(cost);
        }
    }
}
