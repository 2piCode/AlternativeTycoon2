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


        void Start()
        {
            base.Awake();

            costField.interactable = false;
            countField.contentType = InputField.ContentType.IntegerNumber;
            countField.textComponent.alignment = TextAnchor.MiddleCenter;

            performOperationButton.onClick.AddListener(() => performOperation());
            countField.onValueChanged.AddListener(delegate { ChangePrice(); });
        }

        private void performOperation()
        {
            int count = Convert.ToInt32(countField.text);

            foreach (var company in GameManager.singleton.Companies.Values)
            {
                if (company.Name == companies.options[companies.value].text)
                {
                    if (financeOperation.options[financeOperation.value].text == "Stock")
                        company.BuyStocks(count);
                    else
                        company.BuyBonds(count);
                }
            }

            appScreenImage.SetActive(false);
            computerScreenImage.SetActive(true);
        }

        private void ChangePrice()
        {  
            foreach (var company in GameManager.singleton.Companies.Values)
            {
                if (company.Name == companies.options[companies.value].text)
                {
                    double cost = company.costBond;
                    if (financeOperation.options[financeOperation.value].text == "Stock")
                        cost = company.costStock;
                    
                    costField.text = (Convert.ToInt32(countField.text) * cost).ToString() + "$";
                    costField.textComponent.alignment = TextAnchor.MiddleCenter;
                    return;
                }
            }
        }
    }
}


