using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Currency;
using Shop;

namespace Exchange
{
    public class Exchange : MonoBehaviour
    {
        [SerializeField] private Image _changeResourseImage;
        [SerializeField] private Image _resultResourceImage;
        [SerializeField] private Text _costText;
        [SerializeField] private Text _resultText;
        [SerializeField] private Button _button;

        private Currency.Currency _changeResourse;
        private Currency.Currency _resultResource;
        private ViewCurrency _viewCurrency;
        private Bank _bank;

        private int _cost;
        private int _result;

        public void Init(Currency.Currency changeResource, 
                        Currency.Currency resultResource, 
                        ViewCurrency viewCurrency, 
                        Bank bank,
                        int cost, 
                        int result)
        {
            _changeResourse = changeResource;
            _resultResource = resultResource;
            _viewCurrency = viewCurrency;
            _bank = bank;

            _cost = cost;
            _result = result;
        }
        
        private void Start()
        {
            _button.onClick.AddListener(ExcahngeResources);
            _changeResourseImage.sprite = _changeResourse.sprite;
            _resultResourceImage.sprite = _resultResource.sprite;
            _costText.text = _cost.ToString();
            _resultText.text = _result.ToString();
        }

        private void ExcahngeResources()
        {
            if (PlayerPrefs.GetInt(_changeResourse.playerPrefsName) >= _cost)
            {
                _bank.SpendResource(_changeResourse.playerPrefsName, _cost);
                _bank.AddResource(_resultResource.playerPrefsName, _result);
                _viewCurrency.UpdateUI();
            }
        }
    }
}
