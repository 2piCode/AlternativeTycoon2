using System.Collections.Generic;

namespace Game
{
	public enum Genre
	{
		Technology,
		Magic,
		Realism,
		SciFi
	}

	public class Mod
	{
		public readonly string name;
		public readonly Genre genre;
		private List<Country> countries;
		private int cost;//of making
		private double price;
		private int amountOfSoldCopies;
		public double Revenue => price * amountOfSoldCopies;//from sells

		public Mod(string name, Genre genre, List<Country> countries, int cost, double price)
		{
			this.name = name;
			this.genre = genre;
			this.countries = countries;
			this.cost = cost;
			this.price = price;
		}
	}
}
