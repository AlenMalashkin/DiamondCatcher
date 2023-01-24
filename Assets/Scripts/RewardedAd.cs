using System;
using System.Collections;
using System.Collections.Generic;
using Currency;
using Shop;
using UnityEngine;
using YG;
using Random = UnityEngine.Random;

namespace Ads
{
    public class RewardedAd : MonoBehaviour
    {
        [SerializeField] private int _adID;
        [SerializeField] private int _resourceCount;
        
        [SerializeField] private Bank _bank;
        [SerializeField] private ViewCurrency _viewCurrency;
        [SerializeField] private Currency.Currency[] _currencies;
        
        private void OnEnable()
        {
            YandexGame.CloseVideoEvent += Reward;
        }

        private void OnDisable()
        {
            YandexGame.CloseVideoEvent -= Reward;   
        }

        private void Reward(int id)
        {
            if (id == _adID)
                AddResource(_resourceCount);
        }

        private void AddResource(int count)
        {
            var resourceName = _currencies[Random.Range(0, _currencies.Length)].playerPrefsName;
            _bank.AddResource(resourceName, count);
            _viewCurrency.UpdateUI();
        }
    }
}