using System.Collections.Generic;
using UnityEngine;
using FallingItems;

namespace Factories
{
    public class DefaultItemFactory : GenericFactory<Item>
    {
        [SerializeField] private List<Currency.Currency> _currencies;

        public override Item Spawn()
        {
            var item = base.Spawn();
            
            var curr = _currencies[Random.Range(0, _currencies.Count)];

            item.Init(Random.Range(0.5f, 2), curr.sprite, curr.damage, curr.playerPrefsName);

            return item;
        }

        public void InitSpritesList(List<Currency.Currency> currencies)
        {
            _currencies = currencies;
        } 
    }
}

