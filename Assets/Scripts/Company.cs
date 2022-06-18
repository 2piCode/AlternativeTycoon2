using System.Collections.Generic;

namespace Game
{
	public enum Activity
	{
		Oil
		
	}

	public class Company
	{
		public readonly string Name;
		public readonly string ActivityField;
		
		public readonly double costStock;
		public int countStocks { get; private set; }
		public readonly double amountOfStockPayment;

		public readonly double costBond;
		public int countBonds { get; private set; }
		public readonly double amountOfBondPayment;

		public Company(string name, double costStock, int countStocks, double amountOfStockPayment,
			double costBond, int countBonds, double amountOfBondPayment)
		{
			this.Name = name;

			this.costStock = costStock;
			this.countStocks = countStocks;
			this.amountOfStockPayment = amountOfStockPayment;

			this.costBond = costBond;
			this.countBonds = countBonds;
			this.amountOfBondPayment = amountOfBondPayment;
		}
	}
}