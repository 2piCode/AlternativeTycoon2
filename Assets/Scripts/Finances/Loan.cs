using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Math;

namespace Game 
{
    public class Loan : IBankFinance
    {
        public Loan(double cost, double percent, int periodInMonths, int periodOfPaymentInMonths = 1) : 
            base(cost, percent, periodInMonths, periodOfPaymentInMonths)
        {

        }
        
        public override void Buy(double amount)
        {
            GameManager.singleton.onFinishDay += MakePayment;
            onPayment += GameManager.singleton.player.AddMoney;
            OnPayment(amount);
        }

        public override void Sell(double amount)
        {
            GameManager.singleton.onFinishDay -= MakePayment;
            onPayment -= GameManager.singleton.player.AddMoney;
            OnPayment(amount);
        }

        public override void MakePayment()
        {
            if (GameManager.singleton.currentDate - NextPaymentDate >= 0) {
                OnPayment(-monthPayment);
                currentCost -= monthPayment;
                NextPaymentDate.AddMonths(periodOfPaymentInMonths);
            }

            if (GameManager.singleton.currentDate - EndDate >= 0) 
                Sell(0);
        }

        public override double monthPayment =>
            Math.Round(purchaseCost / GameDateTime.GetMonthsInPeriod(StartDate, EndDate) + 
                currentCost * (percent / 100) / 12, 1);
    }
}

