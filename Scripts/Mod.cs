using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		private int countSold;
		public int Revenue => price * countSold;//from sells

		public Mod(string name, Genre genre, List<Country> countries, int cost, double price)
		{
			this.name = name;
			this.genre = genre;
			this.countries = countries;
			this.cost = cost;
		}
	}
}
