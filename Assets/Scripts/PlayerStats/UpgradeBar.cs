using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Currency;
using Shop;

namespace PlayerUpgradeMenu
{
    public class UpgradeBar : MonoBehaviour
    {
        [SerializeField] private Image _statImage;
        [SerializeField] private Image _currencyImage;
        [SerializeField] private Text _upgradeCost;
        [SerializeField] private Button _upgradeButton;

        private Currency.Currency _resourceForUpgrade;
        private StatsView _statsView;
        private Bank _bank;
        private ViewCurrency _viewCurrency;
        private StatData _statData;
        private int[] _costPerLevel;
        private string _inGamePlayerPrefsStatName;

        private Dictionary<string, StatData> _pushStatsIntoGame;

        private void Start()
        {
            _upgradeButton.onClick.AddListener(UpgradeItem);

            CheckMaxUpgradeLevel();
        }

        public void Init(StatData statData,
                        int[] upgradeCosts, 
                        Currency.Currency resourceForUpgrade, 
                        StatsView statsView, 
                        Bank bank, 
                        ViewCurrency viewCurrency,
                        string inGamePlayerPrefsStatName)
        {
            _statData = statData;
            _costPerLevel = upgradeCosts;
            _resourceForUpgrade = resourceForUpgrade;
            _statsView = statsView;
            _bank = bank;
            _viewCurrency = viewCurrency;
            _inGamePlayerPrefsStatName = inGamePlayerPrefsStatName;

            _currencyImage.sprite = resourceForUpgrade.sprite;
            _statImage.sprite = statData.sprite;
            _upgradeCost.text = upgradeCosts[PlayerPrefs.GetInt(statData.getUpgradeLevelByPlayerPrefsName)].ToString();
        }

        private void UpgradeItem()
        {
            if (PlayerPrefs.GetInt(_resourceForUpgrade.playerPrefsName) >= _costPerLevel[PlayerPrefs.GetInt(_statData.getUpgradeLevelByPlayerPrefsName, 0)])
            {
                var currLevel = PlayerPrefs.GetInt(_statData.getUpgradeLevelByPlayerPrefsName, 0);

                _bank.SpendResource(_resourceForUpgrade.playerPrefsName, _costPerLevel[currLevel]);

                currLevel++;

                PlayerPrefs.SetInt(_statData.getUpgradeLevelByPlayerPrefsName, currLevel);

                PlayerPrefs.SetInt(_inGamePlayerPrefsStatName, _statData.statPowerLevels[currLevel]);

                UpdateUI();
            }
        }

        private void UpdateUI()
        {
            CheckMaxUpgradeLevel();
            _viewCurrency.UpdateUI();
            _statsView.UpdateUI();
        }

        private void CheckMaxUpgradeLevel()
        {
            if (PlayerPrefs.GetInt(_statData.getUpgradeLevelByPlayerPrefsName) == 4)
            {
                _upgradeCost.text = "Max";
                _upgradeButton.interactable = false;
                _upgradeButton.image.color = new Color32(255, 255, 255, 150);
            }
            else
            {
                _upgradeCost.text = _costPerLevel[PlayerPrefs.GetInt(_statData.getUpgradeLevelByPlayerPrefsName)].ToString();
            }
        }
    }    
}

