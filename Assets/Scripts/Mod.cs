using UnityEngine.Events;
using UnityEngine;
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
		public readonly bool efficiency;
		public readonly bool graphics;
		public readonly bool promotion;
		public int amountOfSoldCopies { get; private set; }
		public double Revenue => price * amountOfSoldCopies;//from sells

		public Mod(string name, Genre genre, Country country, 
			double cost, double price, bool efficiency = false, bool graphics = false, bool promotion = false)
		{
			this.name = name;
			this.genre = genre;
			this.country = country;
			this.cost = cost;
			this.price = price;
			this.efficiency = efficiency;
			this.graphics = graphics;
			this.promotion = promotion;
		}

		public Mod(SerializableMod mod)
		{
			this.name = mod.name;
			this.genre = mod.genre;
			this.country = mod.country;
			this.cost = mod.cost;
			this.price = mod.price;
		}

		public static Genre GetGenre(string genre)
		{
			switch (genre)
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

		public void MakePayment()
		{
			double rate = default(double);
			foreach (var a in country.rateForGenre)
				if (a.Item1 == genre)
					rate = a.Item2;

			System.Random random = new System.Random();
			//Debug.Log(Convert.ToInt32(price - Convert.ToDouble(promotion) * price / 2 -
			//	Convert.ToDouble(efficiency) * price / 10 -
			//	Convert.ToDouble(graphics) * price / 10));
			if (random.Next(0, Convert.ToInt32(price - Convert.ToDouble(promotion) * price / 2 - 
				Convert.ToDouble(efficiency) * price / 10 - 
				Convert.ToDouble(graphics) * price / 10)) < rate)
			{
				GameManager.singleton.player.AddMoney(price);
				Debug.Log("Add Money");
			}
		}

		public void Release()
		{
			GameManager.singleton.onFinishDay += MakePayment;

			GameManager.singleton.Mods[$"{name}"] = this;
			onRelease.Invoke();
		}

		public static UnityEvent onRelease = new UnityEvent();
	}
}
