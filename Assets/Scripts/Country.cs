using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Xml.Serialization;

namespace Game
{
	public class Country
	{	
		public readonly string Name;
		public readonly int Population;
		public List<(Genre, double)> rateForGenre { get; private set; }

		public Country() { }

		public Country(string name, int population, List<(Genre, double)> rateForGenre)
		{
			this.Name = name;
			this.Population = population;
			this.rateForGenre = rateForGenre;
		}

		public Country(SerializableCountry country)
		{
            this.Name = country.Name;
            this.Population = country.Population;
            this.rateForGenre = country.rateForGenre;
		}

		public static Country SearchCountry(string name)
		{
			List<Country> countries = GetCountriesFromFile();
			return countries
				.Where(country => country.Name == name)
				.FirstOrDefault();
		}

		private static List<Country> GetCountriesFromFile() =>
			GameManager.singleton.Countries.Values.ToList();
	}
}