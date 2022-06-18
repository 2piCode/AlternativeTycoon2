using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Game
{
    public class StockExChange : IFinancialInstitution
    {
        public StockExChange() : base()
        {
        }

        //public double monthPayment => stocks.Values.Select(x => x.amountOfPayment / ).Sum() + loans.Select(x => x.monthPayment).Sum();

        public Dictionary<Company, Stock> stocks = new Dictionary<Company, Stock>();
        public Dictionary<Company, Bond> bonds = new Dictionary<Company, Bond>();


        public void BuyStocks(int amount, Company company)
        {
            Stock stock;
            if (!stocks.ContainsKey(company))
            {
                stock = new Stock(company.costStock, company);
                stocks[company] = stock;
            }
            stock = stocks[company];
            stock.Buy(amount);
        }
        public void SellStocks(int amount, Company company)
        {
            Stock stock = stocks[company];
            stock.Sell(amount);
        }
        public void BuyBonds(int amount, Company company)
        {
            Bond bond;
            if (!bonds.ContainsKey(company))
            {
                bond = new Bond(company.costBond, company);
                bonds[company] = bond;
            }
            bond = bonds[company];
            bond.Buy(amount);
        }

        public void SellBonds(int amount, Company company)
        {
            Bond bond = bonds[company];
            bond.Sell(amount);
        }
    }
}
