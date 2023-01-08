using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boosters
{
    [CreateAssetMenu(fileName = "Booster", menuName = "Boosters", order = 4)]
    public class BoostData : ScriptableObject
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private string _boostName;

        public Sprite sprite => _sprite;
        public string boostName => _boostName;
    }
}

