using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class SecuritiesCanvas : IComputerApp
    {
        [Header("App settings")]
        [SerializeField] private Dropdown financeOperation;
        [SerializeField] private Dropdown companies;

        [SerializeField] private Button performOperationButton;

        [SerializeField] private InputField countField;
        [SerializeField] private InputField costField;
        [SerializeField] private InputField paymentField;

        void Start()
        {
            base.Awake();

            costField.interactable = false;
            paymentField.interactable = false;
            //countField.contentType = InputField.ContentType.Alphanumeric
            countField.textComponent.alignment = TextAnchor.MiddleCenter;
            paymentField.textComponent.alignment = TextAnchor.MiddleCenter;

            performOperationButton.onClick.AddListener(() => performOperation());
            countField.onValueChanged.AddListener(delegate { ChangePrice(); });
        }

        private void performOperation()
        {
            int count = Convert.ToInt32(countField.text);

            Company company = GameManager.singleton.Companies[companies.options[companies.value].text];

            if (financeOperation.options[financeOperation.value].text == "Stock")
                GameManager.singleton.stockExChange.BuyStocks(count, company);
            else
                GameManager.singleton.stockExChange.BuyBonds(count, company);

            appScreenImage.SetActive(false);
            computerScreenImage.SetActive(true);
        }

        private void ChangePrice()
        {
            if (countField.text == "")
                return;
            
            Company company = GameManager.singleton.Companies[companies.options[companies.value].text];
            double cost;
            int count = Convert.ToInt32(countField.text);

            if (financeOperation.options[financeOperation.value].text == "Bond")
            {
                cost = company.costBond;
                paymentField.text = $"{company.amountOfBondPayment * count}$";
            }
            else
            {
                cost = company.costStock;
                paymentField.text = $"{company.amountOfStockPayment * count}$";
            }

            if (count * cost > GameManager.singleton.player.Money)
                performOperationButton.interactable = false;
            else
                performOperationButton.interactable = true;

            costField.text = (count * cost).ToString() + "$";
            costField.textComponent.alignment = TextAnchor.MiddleCenter;
        }

        private void ChangePeriod()
        {

        }
    }
}


