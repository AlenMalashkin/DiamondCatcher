using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerUpgradeMenu
{
    [CreateAssetMenu(fileName = "StatData", menuName = "Stats", order = 3)]
    public class StatData : ScriptableObject
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private string _getUpgradeLevelByPlayerPrefsName;
        [SerializeField] private string _inGamePlayerPrefsStatName;
        [SerializeField] private int[] _statPowerLevels;

        public Sprite sprite => _sprite;
        public string getUpgradeLevelByPlayerPrefsName => _getUpgradeLevelByPlayerPrefsName;
        public string inGamePlayerPrefsStatName => _inGamePlayerPrefsStatName;
        public int[] statPowerLevels => _statPowerLevels;
    }    
}

