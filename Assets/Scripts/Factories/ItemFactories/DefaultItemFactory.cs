using System.Collections.Generic;
using UnityEngine;
using FallingItems;

namespace Factories
{
    public class DefaultItemFactory : GenericFactory<DefaultItem>
    {
        [SerializeField] private List<Currency.Currency> _currencies;
        [SerializeField] private float maxSpeed;
        [SerializeField] private float minSpeed;

        public override DefaultItem Spawn()
        {
            var item = base.Spawn();
            
            var curr = _currencies[Random.Range(0, _currencies.Count)];

            item.Init(Random.Range(minSpeed, maxSpeed), curr.sprite, curr.damage, curr.playerPrefsName);

            return item;
        }

        public void InitCurrenciesList(List<Currency.Currency> currencies)
        {
            _currencies = currencies;
        }

        public void IncreaseItemSpeed()
        {
            if (minSpeed < 2f)
                minSpeed += 0.01f;

            if (maxSpeed < 3f)
                maxSpeed += 0.01f;
        }
    }
}

