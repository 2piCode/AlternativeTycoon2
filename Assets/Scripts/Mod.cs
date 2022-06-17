using System.Collections.Generic;
using System;

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
		public readonly Country country;
		public readonly double cost;//of making
		public readonly double price;
		public int amountOfSoldCopies { get; private set; }
		public double Revenue => price * amountOfSoldCopies;//from sells

		public Mod(string name, Genre genre, Country country, double cost, double price)
		{
			this.name = name;
			this.genre = genre;
			this.country = country;
			this.cost = cost;
			this.price = price;
		}

		public Mod(SerializableMod mod)
		{
			this.name = mod.name;
			this.genre = mod.genre;
			this.country = mod.country;
			this.cost = mod.cost;
			this.price = mod.price;
		}

		static public Genre GetGenre(string genre)
		{
			switch(genre)
			{
				case "Technology":
					return Genre.Technology;
				case "Magic":
					return Genre.Magic;
				case "Realism":
					return Genre.Realism;
				case "SciFi":
					return Genre.SciFi;
				default:
					return default(Genre);
			}
		}

		 
	}
}
