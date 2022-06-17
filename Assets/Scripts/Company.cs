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

		private double capitalization;

		public readonly double costStock;
		public int countStocks { get; private set; }
		public readonly double percentStock;

		public readonly double costBond;
		public int countBonds { get; private set; }
		public readonly double percentBond;
		public readonly int periodBond;

		public Company(string name, double costStock, int countStocks, double percentStock,
			double costBond, int countBonds, double percentBond, int periodBond)
		{
			this.Name = name;

			this.costStock = costStock;
			this.countStocks = countStocks;
			this.percentStock = percentStock;

			this.costBond = costBond;
			this.countBonds = countBonds;
			this.percentBond = percentBond;
			this.periodBond = periodBond;
		}

		public bool BuyStocks(int count)
		{
			if (count > countStocks)
				return false;

			countStocks -= count;
			return true;
		}

		public bool BuyBonds(int count)
		{
			if (count > countBonds)
				return false;

			countStocks -= count;
			return true;
		}
	}
}