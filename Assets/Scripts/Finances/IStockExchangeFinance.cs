using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public abstract class IStockExchangeFinance : IFinance
    {
        public IStockExchangeFinance(double purchaseCost, Company company, int periodInMonths = -1, int periodOfPaymentInMonths = 6) : 
            base(purchaseCost, periodInMonths, periodOfPaymentInMonths)
        {
            this.amount = 0;
            this.company = company;
        }

        public int amount { get; protected private set; }
        protected private Company company;
        public abstract double amountOfPayment { get; }
    }
}
