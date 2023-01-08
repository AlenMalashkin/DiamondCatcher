using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerUpgradeMenu
{
    [CreateAssetMenu(fileName = "UpgradeBar", menuName = "Upgrade Bars", order = 4)]
    public class UpgradeBarData : ScriptableObject
    {
        [SerializeField] private StatData _statData;
        [SerializeField] private int[] _upgradeCosts;
        [SerializeField] private Currency.Currency _currency;

        public StatData statData => _statData;
        public int[] upgradeCosts => _upgradeCosts;
        public Currency.Currency currency => _currency;
    }    
}

