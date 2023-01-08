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
        [SerializeField] private Button _button;
        [SerializeField] private Bank _bank;
        [SerializeField] private Currency.Currency _changeResourse;
        [SerializeField] private Currency.Currency _resultResource;
        [SerializeField] private ViewCurrency _viewCurrency;

        [SerializeField] private int _cost;
        [SerializeField] private int _result;

        private void Awake()
        {
            _button.onClick.AddListener(ExcahngeResources);
        }

        private void ExcahngeResources()
        {
            if (PlayerPrefs.GetInt(_changeResourse.playerPrefsName) > _cost)
            {
                _bank.SpendResource(_changeResourse.playerPrefsName, _cost);
                _bank.AddResource(_resultResource.playerPrefsName, _result);
                _viewCurrency.UpdateUI();
            }
        }
    }
}
