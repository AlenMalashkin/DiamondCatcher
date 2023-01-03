using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(fileName = "Product", menuName = "Product Params", order = 1)]
    public class Product : ScriptableObject
    {
        [SerializeField] private Sprite _image;
        [SerializeField] private Currency.Currency _currency;
        [SerializeField] private string _productName;
        [SerializeField] private int _cost;
        [SerializeField] private string _playerPrefsSaveName;

        public Sprite image => _image;
        public Currency.Currency currency => _currency;
        public string productName => _productName;
        public int cost => _cost;
        public string playerPrefsSaveName => _playerPrefsSaveName;
    } 
}
