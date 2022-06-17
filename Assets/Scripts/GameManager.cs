using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public delegate void OnFinishDay();
        public event OnFinishDay onFinishDay;
        public static GameManager singleton { get; private set; }
        public GameDateTime currentDate { get; private set; }
        public Player player { get; private set; }
        public Dictionary<string, Achievment> Achievments { get; set; }
        public Dictionary<string, Company> Companies { get; set; }
        public Dictionary<string, Country> Countries { get; set; }
        public Dictionary<string, Mod> Mods { get; set; }

        #region Finance
        public Bank bank = new Bank(10, 6, 10, 6);
        #endregion

        void Awake()
        {
            player = new Player();
            singleton = this;
            Achievments = new Dictionary<string, Achievment>();
            Countries = new Dictionary<string, Country>();
            Companies = new Dictionary<string, Company>();
            Mods = new Dictionary<string, Mod>();
            currentDate = new GameDateTime(2020, 1, 1);
        }

        void Start()
        {
            // Loan loan = new Loan(1000, 10, 1);
            //Deposit deposit = new Deposit(1000, 10, 12, 1);
            //deposit.Buy(100);

            #region generating Achievments

            //Achievments["mod_create"] = new Achievment("mod_create", "Вход в индустрию", "Выпустил свой первый мод", "Мама мне не нужны твои деньги");
            //Achievments["credit_first"] = new Achievment("credit_first", "Должник", "Опробовал банковскую систему", "Взял деньги у людей, придется возвращать");
            #endregion
            #region generating Countires
            // List<(Genre, double)> dep = new List<(Genre, double)>();
            // dep.Add((Genre.Technology, 80));
            // dep.Add((Genre.Magic, 90));
            // dep.Add((Genre.Realism, 40));
            // dep.Add((Genre.SciFi, 70));
            // Countries["Russia"] = new Country("Russia", 10000, dep);
            // Countries["Canada"] = new Country("Canada", 10000, dep);
            // Countries["USA"] = new Country("USA", 10000, dep);
            // Countries["Japan"] = new Country("Japan", 10000, dep);
            // SerializableCountry.SerializeXml();
            #endregion
            #region generating
            #endregion
            SerializableAchievment.SerializeXml();

            foreach (var item in SerializableCountry.DeSerializeXml())
            {
                Countries[item.Name] = new Country(item);
            }

            Companies["Company 1"] = new Company("Company 1", 150, 10, 2.3, 60, 15, 1.4, 6);
            Companies["Company 2"] = new Company("Company 2", 150, 10, 2.3, 60, 15, 1.4, 6);
            Companies["Company 3"] = new Company("Company 3", 150, 10, 2.3, 60, 15, 1.4, 6);

            // foreach (var item in SerializableAchievment.DeSerializeXml())
            // {
            //     Achievments[item.id] = new Achievment(item);
            // }

            //foreach (var item in SerializableMod.DeSerializeXml())
            //{
            //    Mods[item.name] = new Mod(item);
            //}

            #region writeInNote

            #endregion
        }

        public void FinishDay()
        {
            currentDate = currentDate.AddDays(1);
            onFinishDay?.Invoke();
        }
    }
    
}
