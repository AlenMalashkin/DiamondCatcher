using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        [SerializeField] private Text _lockText;

        private Bank _bank;

        private ViewCurrency _viewCurrency;
        private Currency.Currency _currency;
        private int _price;
        private string _playerPrefsSaveName;

        private void Start()
        {
            if (!BoughtCheck())
            {
                _button.onClick.AddListener(Buy);
            } 
            else
            {
                UpdateButton();
                _button.onClick.AddListener(StartGame);
            }
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
                _button.image.color = new Color32(47, 185, 214, 255);
                _itemImage.color = new Color32(255, 255, 255, 255);
                return true;
            }
            
            _itemImage.color = new Color32(255, 255, 255, 150);
            _button.image.color = new Color32(47, 185, 214, 150);
            return false;
        }

        private void Buy()
        {
            if (PlayerPrefs.GetInt(_currency.playerPrefsName) > _price)
            {
                _bank.SpendResource(_currency.playerPrefsName, _price);
                PlayerPrefs.SetString(_playerPrefsSaveName, "Bought");
                BoughtCheck();
                _viewCurrency.UpdateUI();
                _button.onClick.RemoveListener(Buy);
                _button.onClick.AddListener(StartGame);
                UpdateButton();
            }    
        }

        private void StartGame()
        {
            PlayerPrefs.SetString("CurrentLocation", _playerPrefsSaveName);
            SceneManager.LoadScene(1);
        }

        private void UpdateButton()
        {
            _lockText.gameObject.SetActive(false);
            _priceText.gameObject.SetActive(false);
        }
    }    
}

