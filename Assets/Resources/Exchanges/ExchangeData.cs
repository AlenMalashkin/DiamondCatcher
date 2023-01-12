using System.Collections;
using System.Collections.Generic;
using Shop;
using UnityEngine;

namespace Exchange
{
    [CreateAssetMenu(fileName = "Exchange", menuName = "Exchanges", order = 4)]
    public class ExchangeData : ScriptableObject
    {
        [SerializeField] private Currency.Currency _changeResourse;
        [SerializeField] private Currency.Currency _resultResource;

        [SerializeField] private int _cost;
        [SerializeField] private int _result;
        
        public Currency.Currency changeResourse => _changeResourse;
        public Currency.Currency resultResource => _resultResource;
        public int cost => _cost;
        public int result => _result;
    }    
}

