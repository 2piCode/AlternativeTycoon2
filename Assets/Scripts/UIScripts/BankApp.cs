using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game 
{
    public class BankApp : IComputerApp
    {
        [Header("App settings")]
        [SerializeField] private Dropdown financeOperation;

        [SerializeField] private Button performOperationButton;
            
        [SerializeField] private Slider costSlider;
        [SerializeField] private InputField costField;

        protected override void Awake()
        {
            base.Awake();
            costSlider.minValue = 100;
            costSlider.maxValue = 10000;

            costField.interactable = false;

            performOperationButton.onClick.AddListener(() => performOperation());
            costSlider.onValueChanged.AddListener(delegate { ChangePrice(); });
        }

        private void performOperation()
        {
            double amountOfMoney = Math.Round(costSlider.value, 1);
            switch(financeOperation.options[financeOperation.value].text)
            {
                case "Loan":
                    GameManager.singleton.bank.GiveLoan(amountOfMoney);
                    break;
                case "Deposit":
                    GameManager.singleton.bank.MakeDeposit(amountOfMoney);
                    break;
                default:
                    throw new Exception();
            }
            appScreenImage.SetActive(false);
            computerScreenImage.SetActive(true);
        }

        private void ChangePrice()
        {
            double amountOfMoney = Math.Round(costSlider.value, 1);
            if (financeOperation.options[financeOperation.value].text == "Deposit" &&
                amountOfMoney > GameManager.singleton.player.Money)
                performOperationButton.interactable = false;
            else
                performOperationButton.interactable = true;

            costField.text = Convert.ToString(Math.Round(costSlider.value, 0)) + "$";
            costField.textComponent.alignment = TextAnchor.MiddleCenter;
        }
    }
}
