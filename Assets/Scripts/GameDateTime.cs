using System;
using UnityEngine;
namespace Game
{
	public class GameDateTime
	{
		public int Day => date.Day;
		public int Month => date.Month;
		public int Year => date.Year;
		public DateTime date;

		public GameDateTime()
		{
			date = new DateTime(2021, 1, 1);
		}

		public GameDateTime(GameDateTime gameDateTime)
		{
			date = gameDateTime.date;
		}

		public GameDateTime(DateTime dateTime)
		{
			date = dateTime;
		}

		public GameDateTime(int year, int month, int day)
		{
			date = new DateTime(year, month, day);
		}

		public GameDateTime(GameDateTime startPeriod, int period)
		{
			if (period <= 0)
				throw new ArgumentException("Period cannot be less or equal to zero.");
			this.date = startPeriod.date.AddDays(period);
		}

		public static int operator -(GameDateTime leftDate, GameDateTime rightDate)
		{
			return (int)(leftDate.date - rightDate.date).TotalDays;
		}

		public GameDateTime AddDays(int numberOfDays)
		{
			return new GameDateTime(date.AddDays(numberOfDays));
		}

		public GameDateTime AddMonths(int numberOfMonths)
		{
			return new GameDateTime(date.AddMonths(numberOfMonths));
		}

		public GameDateTime AddYears(int numberOfYears)
		{
			return new GameDateTime(date.AddYears(numberOfYears));
		}

		public static int GetMonthsInPeriod(GameDateTime startPeriod, GameDateTime endPeriod) 
		{
			if (startPeriod.date.CompareTo(endPeriod.date) == 1) 
				throw new ArgumentException("Start period cannot be later than end period.");
			return (endPeriod.Month - startPeriod.Month) + 12 * (endPeriod.Year - startPeriod.Year);
		}

		public override string ToString()
		{
			return date.Year.ToString() + '.' +
				   date.Month.ToString() + '.' +
				   date.Day.ToString();
		}
	}
}