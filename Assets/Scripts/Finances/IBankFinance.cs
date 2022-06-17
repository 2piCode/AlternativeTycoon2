using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public abstract class IBankFinance : IFinance
    {
        public IBankFinance(double purchaseCost, double percent, int periodInMonths, int periodOfPaymentInMonths = 1) : 
            base(purchaseCost, periodInMonths, periodOfPaymentInMonths)
        {
            this.percent = percent;
        }

        public readonly double percent;

        public abstract double monthPayment {get;}
    }
}
