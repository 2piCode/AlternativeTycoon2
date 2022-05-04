namespace Game
{
	public abstract class IFinance 
	{
		public readonly double cost;
		public readonly double actualRevenue; //сколько на данный момент получил
		public readonly double projectedRevenue; //сколько должен получить

		public abstract void Buy();
		public abstract void Sell();
	}
}
