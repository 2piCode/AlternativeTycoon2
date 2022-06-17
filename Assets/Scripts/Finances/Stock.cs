using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Stock : IStockExchangeFinance
    {
        public Stock(double purchaseCost, Company company, int periodInMonths, int periodOfPaymentInMonths = 6) : 
            base(purchaseCost, company, periodInMonths, periodOfPaymentInMonths)
        { }
        
        public override void Buy(double amount)
        {
            double costOfStocks = amount * purchaseCost;
            GameManager.singleton.player.AddMoney(costOfStocks);
            OnPayment(-costOfStocks);
        }

        public override void Sell(double amount)
        {
            double costOfStocks = amount * purchaseCost;
            OnPayment(-costOfStocks);
            GameManager.singleton.player.AddMoney(costOfStocks);
        }

        public override void MakePayment()
        {
            if (GameManager.singleton.currentDate - NextPaymentDate <= 0) {
                GameManager.singleton.player.AddMoney(amountOfPayment);
                OnPayment(amountOfPayment);
            }
        }

        // доделать
        public override double amountOfPayment => currentCost;
    }
}
