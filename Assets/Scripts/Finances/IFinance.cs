using System;

namespace Game
{
	public abstract class IFinance
	{
		public IFinance(double purchaseCost, int periodInMonths, int periodOfPaymentInMonths = 1)
		{
			this.purchaseCost = purchaseCost;
			this.currentCost = purchaseCost;
			this.periodOfPaymentInMonths = periodOfPaymentInMonths;
			StartDate = GameManager.singleton.currentDate;
			EndDate = new GameDateTime(StartDate).AddMonths(periodInMonths);
			NextPaymentDate = new GameDateTime(StartDate).AddMonths(periodOfPaymentInMonths);
		}

		public readonly double purchaseCost;
		private protected double currentCost;
		public readonly double projectedRevenue; //сколько должен получить
		public double actualRevenue => currentCost - purchaseCost; //сколько на данный момент получил

		public GameDateTime StartDate {get; private set;}
		public GameDateTime EndDate {get; private set;}
		public GameDateTime NextPaymentDate {get; protected private set;}
		public int periodOfPaymentInMonths {get; private set;}

		public abstract void Buy(double amount);
		public abstract void Sell(double amount);
		public abstract void MakePayment();

		public delegate void OnPay(double cost);
      	public event OnPay onPayment;

		protected virtual void OnPayment(double cost)
		{
			onPayment?.Invoke(cost);
		}
	}
}
