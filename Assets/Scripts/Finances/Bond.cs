using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Bond : IStockExchangeFinance
    {
        public Bond(double purchaseCost, Company company, int periodInMonths, int periodOfPaymentInMonths = 6) : 
            base(purchaseCost, company, periodInMonths, periodOfPaymentInMonths)
        {

        }
        
        public override void Buy(double amount)
        {
            double costOfBonds = amount * purchaseCost;
            GameManager.singleton.player.AddMoney(costOfBonds);
            OnPayment(-costOfBonds);
        }

        public override void Sell(double amount)
        {
            double costOfBonds = amount * purchaseCost;
            OnPayment(-costOfBonds);
            GameManager.singleton.player.AddMoney(costOfBonds);
        }

        public override void MakePayment()
        {
            if (GameManager.singleton.currentDate - NextPaymentDate <= 0) {
                GameManager.singleton.player.AddMoney(amountOfPayment);
                OnPayment(amountOfPayment);
            }
        }

        // доделать
        // return Company.BondPayment
        public override double amountOfPayment {get {return 1;}}
    }
}
