using System.Collections.Generic;
using UnityEngine;
using FallingItems;

namespace Factories
{
    public class DefaultItemFactory : GenericFactory<DefaultItem>
    {
        [SerializeField] private List<Currency.Currency> _currencies;
        [SerializeField] private float _currMaxSpeed;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _currMinSpeed;

        public override DefaultItem Spawn()
        {
            var item = base.Spawn();
            
            var curr = _currencies[Random.Range(0, _currencies.Count)];

            item.Init(Random.Range(_currMinSpeed, _currMaxSpeed), curr.sprite, curr.damage, curr.playerPrefsName);

            return item;
        }

        public void Init(List<Currency.Currency> currencies, float startMinSpeed, float startMaxSpeed, float minSpeed, float maxSpeed)
        {
            _currencies = currencies;
            _currMaxSpeed = startMaxSpeed;
            _currMinSpeed = startMinSpeed;
            _maxSpeed = maxSpeed;
            _minSpeed = minSpeed;
        }

        public void IncreaseItemSpeed()
        {
            if (_minSpeed > _currMinSpeed)
                _currMinSpeed += 0.01f;

            if (_maxSpeed > _currMaxSpeed)
                _currMaxSpeed += 0.01f;
        }
    }
}

