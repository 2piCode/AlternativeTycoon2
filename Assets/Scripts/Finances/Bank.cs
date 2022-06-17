using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Game
{
    public class Bank : IFinancialInstitution
    {
        public Bank(double loanPercent, int loanPeriodInMonth, double depositPercent, int depositPeriodInMonth) :
            base()
        {
            this.loanPercent = loanPercent;
            this.loanPeriodInMonth = loanPeriodInMonth;
            this.depositPercent = depositPercent;
            this.depositPeriodInMonth = depositPeriodInMonth;
        }

        public double monthPayment {get; private set;}
        public double loanPercent {get; private set;}
        public int loanPeriodInMonth {get; private set;}
        public double depositPercent {get; private set;}
        public int depositPeriodInMonth {get; private set;}

        public List<Loan> loans = new List<Loan>();
        public List<Deposit> deposits = new List<Deposit>();

        public void MakeDeposit(double cost)
        {
            Deposit deposit = new Deposit(cost, depositPercent, depositPeriodInMonth);
            deposit.Buy(cost);
            deposits.Add(deposit);
        }

        public void GiveLoan(double cost)
        {
            Loan loan = new Loan(cost, loanPercent, loanPeriodInMonth);
            loan.Buy(cost);
            loans.Add(loan);
        }
    }
}