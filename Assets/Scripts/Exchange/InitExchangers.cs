
using System;
using System.Collections;
using System.Collections.Generic;
using Currency;
using Shop;
using UnityEngine;

namespace Exchange
{
    public class InitExchangers : MonoBehaviour
    {
        [SerializeField] private ExchangeData[] _exchangeData;
        [SerializeField] private Exchange _exchangePrefab;

        [SerializeField] private ViewCurrency _viewCurrency;
        [SerializeField] private Bank _bank;

        private void Awake()
        {
            for (int i = 0; i < _exchangeData.Length; i++)
            {
                var item = Instantiate(_exchangePrefab, transform, true);

                item.Init(
                    _exchangeData[i].changeResourse,
                    _exchangeData[i].resultResource,
                    _viewCurrency,
                    _bank,
                    _exchangeData[i].cost,
                    _exchangeData[i].result
                    );
                
                item.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}