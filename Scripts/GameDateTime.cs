using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class GameDateTime
	{
		private int TermInDays { get; set; }
		public int year => TermInDays / daysInYear;
		public int month => (TermInDays - year * daysInYear) / monthsInYear;
		public int day => (TermInDays - year * daysInYear - month * monthsInYear) / daysInMonth;
		
		private const int daysInYear = 365;
		private const int daysInMonth = 30;
		private const int monthsInYear = 12;
		

		public GameDateTime()
		{
			TermInDays = 0;
		}

		public void DayEnd()
		{
			TermInDays++;
		}
	}
}
