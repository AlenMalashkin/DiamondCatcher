using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerUpgradeMenu
{
    public class Stat : MonoBehaviour
    {
        [SerializeField] private Image _statImage;
        [SerializeField] private Text _statPowerText;

        private StatData _statData;
        private int[] _statPowerLevels;

        public void Init(StatData statData, int[] statPowerLevels)
        {
            _statData = statData;
            _statPowerLevels = statPowerLevels;

            _statImage.sprite = statData.sprite;
            _statPowerText.text = statPowerLevels[PlayerPrefs.GetInt(statData.getUpgradeLevelByPlayerPrefsName)].ToString();
        }
    }
}
