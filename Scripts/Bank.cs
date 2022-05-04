using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Bank : IFinancialInstitution
    {
        private List<Credit> credits;

        public void GiveCredit(int cost)
        {

        }

        public void MakeDeposit(int cost)
        {

        }

        private bool IsPlayerHaveCredit()
        {
            return default(bool);
        }

        //Возвращает максимальную сумму возможную для кредита
        private double AnalyzePlayerResponsibility()
        {
            return default(double);
        }

        public class Credit
        {
            
        }
    }
}