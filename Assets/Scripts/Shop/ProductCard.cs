using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Currency;
using UnityEngine.EventSystems;

namespace Shop
{
    public class ProductCard : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _itemImage;
        [SerializeField] private Text _itemName;
        [SerializeField] private Text _priceText;

        private Bank _bank;

        private ViewCurrency _viewCurrency;
        private Currency.Currency _currency;
        private int _price;
        private string _playerPrefsSaveName;

        private void Start()
        {
            if (!BoughtCheck())
                _button.onClick.AddListener(Buy);
        }

        public void InitProductCard(Sprite itemImage, Currency.Currency currency, Bank bank, ViewCurrency viewCurrency, string itemName, int price, string playerPrefsSaveName)
        {
            _itemImage.sprite = itemImage;
            _itemName.text = itemName;
            _priceText.text = price.ToString();

            _viewCurrency = viewCurrency;
            _bank = bank;
            _currency = currency;
            _price = price;
            _playerPrefsSaveName = playerPrefsSaveName;
        }

        private bool BoughtCheck()
        {
            if (PlayerPrefs.HasKey(_playerPrefsSaveName))
            {
                _button.interactable = false;
                _button.image.color = new Color32(0, 0, 0, 150);
                return true;
            }

            return false;
        }

        public void Buy()
        {
            if (PlayerPrefs.GetInt(_currency.playerPrefsName) > _price)
            {
                _bank.SpendResource(_currency.playerPrefsName, _price);
                PlayerPrefs.SetString(_playerPrefsSaveName, "Bought");
                PlayerPrefs.SetString("CurrentLocation", _playerPrefsSaveName);
                BoughtCheck();
                _viewCurrency.UpdateUI();
            }    
        }
    }    
}

