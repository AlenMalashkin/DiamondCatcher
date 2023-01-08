using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Currency;
using Shop;

namespace PlayerUpgradeMenu
{
    public class UpgradeMenu : MonoBehaviour
    {
        [SerializeField] private List<UpgradeBarData> _upgradeBars;
        [SerializeField] private UpgradeBar _upgradeBarPrefab;
        [SerializeField] private StatsView _statsView;
        [SerializeField] private Bank _bank;
        [SerializeField] private ViewCurrency _viewCurrency;

        private void Awake()
        {
            for (int i = 0; i < _upgradeBars.Count; i++)
            {
                var upgradeBar = Instantiate(_upgradeBarPrefab);

                upgradeBar.Init(_upgradeBars[i].statData,
                                _upgradeBars[i].upgradeCosts, 
                                _upgradeBars[i].currency, 
                                _statsView,
                                _bank,
                                _viewCurrency,
                                _upgradeBars[i].statData.inGamePlayerPrefsStatName);

                upgradeBar.transform.SetParent(transform);
                upgradeBar.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
