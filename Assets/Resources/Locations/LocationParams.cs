using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Location
{
    [CreateAssetMenu(fileName = "Location", menuName = "Location Params", order = 0)]
    public class LocationParams : ScriptableObject
    {
        [SerializeField] private List<Currency.Currency> _currencies;
        [SerializeField] private Sprite _background;
        [SerializeField] private Sprite _ground;

        public List<Currency.Currency> currencies => _currencies;
        public Sprite background => _background;
        public Sprite ground => _ground;
    }   
}

