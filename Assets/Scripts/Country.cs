using System.Collections.Concurrent;

namespace Game
{
	public class Country
	{
		public readonly string name;
		public readonly int population;
		private ConcurrentDictionary<Genre, double> rateForGenre;

		public Country(string name, int population)
		{
			this.name = name;
			this.population = population;
			//считывание rateForGenre из файла
		}
	}
}