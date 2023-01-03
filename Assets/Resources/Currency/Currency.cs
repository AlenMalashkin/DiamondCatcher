using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Currency
{
    [CreateAssetMenu(fileName = "Currency", menuName = "Add Currency", order = 2)]
    public class Currency : ScriptableObject
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private int _damage;
        [SerializeField] private string _playerPrefsName;

        public Sprite sprite => _sprite;
        public int damage => _damage;
        public string playerPrefsName => _playerPrefsName;
    }    
}

