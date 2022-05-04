using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Company
 	{
 		private string name;
 		private int capitalization;
 		private int countOfWorkers;
 		private List<IWorker> workers;
 		private List<Mod> mod;
 		
 		public void HireWorker(IWorker worker);
 	}
 }