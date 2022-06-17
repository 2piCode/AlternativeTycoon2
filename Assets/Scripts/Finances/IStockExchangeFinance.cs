using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public abstract class IStockExchangeFinance : IFinance
    {
        public IStockExchangeFinance(double purchaseCost, Company company, int periodInMonths, int periodOfPaymentInMonths = 6) : 
            base(purchaseCost, periodInMonths, periodOfPaymentInMonths)
        {
            this.company = company;
        }

        private Company company;
        public abstract double amountOfPayment {get;}
    }
}
