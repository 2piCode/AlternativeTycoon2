using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class ModCreatorApp : IComputerApp
    {
        [Header("App settings")]
        [SerializeField] private InputField name;

        [SerializeField] private Dropdown genreScrollbar;
        [SerializeField] private Dropdown countryScrollbar;

        [SerializeField] private Toggle efficiencyToggle;
        [SerializeField] private Toggle graphicsToggle;
        [SerializeField] private Toggle promotionToggle;
        [SerializeField] private Button createModButton;

        [SerializeField] private InputField costField;
        private double cost;
        
        [SerializeField] private Slider priceSlider;
        [SerializeField] private InputField priceField;

        protected override void Awake()
        {
            base.Awake();
            cost = 0.0;
    
            priceSlider.minValue = 10;
            priceSlider.maxValue = 1000;
            costField.interactable = false;
            priceField.interactable = false;

            createModButton.onClick.AddListener(() => CreateMod());
            priceSlider.onValueChanged.AddListener(delegate { ChangePrice(); });

            efficiencyToggle.onValueChanged.AddListener(delegate { ChangeCost(efficiencyToggle); });
            graphicsToggle.onValueChanged.AddListener(delegate { ChangeCost(graphicsToggle); });
            promotionToggle.onValueChanged.AddListener(delegate { ChangeCost(promotionToggle); });
        }

        private void ResetSettings()
        {
            appScreenImage.SetActive(false);
            computerScreenImage.SetActive(true);

            efficiencyToggle.isOn = false;
            graphicsToggle.isOn = false;
            promotionToggle.isOn = false;

            name.text = "";
            cost = 0;
            costField.text = $"{cost} $";

            priceSlider.value = 0;
            genreScrollbar.value = 0;
            countryScrollbar.value = 0;
        }

        private void CreateMod()
        {
            GameManager.singleton.player.AddMoney(-cost);
            string modName = name.text;
            double costMoney = cost;
            string genre = genreScrollbar.options[genreScrollbar.value].text;
            string country = countryScrollbar.options[countryScrollbar.value].text;
            double price = priceSlider.value;
            ResetSettings();
            GameManager.singleton.Mods[modName] = (new Mod(modName, Mod.GetGenre(genre), Country.SearchCountry(country), costMoney, price));
            SerializableMod.SerializeXml();
        }

        private void ChangeCost(Toggle tglValue)
        {
            if (tglValue.isOn) cost += 100;
            else cost -= 100;
            costField.text = Convert.ToString(cost) + "$";
            //установка текста по центру, я ебался час чтобы найти эту хуйню
            costField.textComponent.alignment = TextAnchor.MiddleCenter;
        }

        private void ChangePrice()
        {
            priceField.text = Convert.ToString(Math.Round(priceSlider.value, 0)) + "$";
            priceField.textComponent.alignment = TextAnchor.MiddleCenter;
        }
    }
}
