using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game
{
    public class Stock : IStockExchangeFinance
    {
        public Stock(double purchaseCost, Company company, int periodInMonths = -1, int periodOfPaymentInMonths = 6) : 
            base(purchaseCost, company, periodInMonths, periodOfPaymentInMonths)
        { }
        
        public override void Buy(double amount)
        {
            GameManager.singleton.onFinishDay += MakePayment;
            onPayment += GameManager.singleton.player.AddMoney;
            double costOfStocks = amount * purchaseCost;
            this.amount += Convert.ToInt32(amount);
            OnPayment(-costOfStocks);
        }

        public override void Sell(double amount)
        {
            double costOfStocks = amount * purchaseCost;
            OnPayment(costOfStocks);
            this.amount -= Convert.ToInt32(amount);
            onPayment -= GameManager.singleton.player.AddMoney;
        }

        public override void MakePayment()
        {
            if (GameManager.singleton.currentDate - NextPaymentDate >= 0) {
                OnPayment(amountOfPayment);
                NextPaymentDate = NextPaymentDate.AddMonths(periodOfPaymentInMonths);
            }
        }

        // доделать
        public override double amountOfPayment => company.costStock * amount;
    }
}
