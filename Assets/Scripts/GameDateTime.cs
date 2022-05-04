using System;

namespace Game
{
	public class GameDateTime
	{
		public DateTime date;

		public GameDateTime()
		{
			date = new DateTime(2020, 1, 1);
		}

		public GameDateTime(GameDateTime gameDateTime)
		{
			date = gameDateTime.date;
		}

		public GameDateTime(int year, int month, int day)
		{
			date = new DateTime(year, month, day);
		}

		public GameDateTime(GameDateTime startOfPeriod, int period)
		{
			if (period < 0)
				throw new ArgumentException("Parameter cannot be less or equal to zero");
			date = startOfPeriod.date;
			AddDays(period);
		}

		public static int operator -(GameDateTime leftDate, GameDateTime rightDate)
		{
			return (int)(leftDate.date - rightDate.date).TotalDays;
		}

		public override string ToString()
		{
			return date.Year.ToString() + '.' +
				   date.Month.ToString() + '.' +
				   date.Day.ToString();
		}

		private GameDateTime(DateTime dateTime)
		{
			date = dateTime;
		}

		public void AddDays(int numberOfDays)
		{
			date.AddDays(numberOfDays);
		}
	}
}