using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Game
{
    public class Scoreboard : MonoBehaviour
    {
        [SerializeField] private GameObject scoreboardCanvas;
        [SerializeField] private Text balanceText;
        [SerializeField] private Text dateText;
        [SerializeField] private Button skipDayButton;
        public delegate void SkipDay();
        public event SkipDay skipDay;

        void Awake(){}

        void Start()
        {
            skipDayButton.onClick.AddListener(() =>
            {
                skipDay?.Invoke();
                UpdateDate();
            });
            scoreboardCanvas.SetActive(true);
            skipDay += GameManager.singleton.FinishDay;
            GameManager.singleton.player.onAddMoney += UpdateBalance;
            GameManager.singleton.onFinishDay += UpdateDate;
            UpdateBalance();
            UpdateDate();
        }

        public void UpdateBalance()
        {
            balanceText.text = $"Balance: {Math.Round(GameManager.singleton.player.Money, 0)}";
        }

        public void UpdateDate()
        {
            dateText.text = $"Date: {GameManager.singleton.currentDate.ToString()}";
        }
    }
}


