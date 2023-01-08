using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerUpgradeMenu
{
    public class StatsView : MonoBehaviour
    {
        [SerializeField] private StatData[] _statsData;
        [SerializeField] private Stat _statPrefab;

        private void Awake()
        {
            CreateItems();
        }

        public void UpdateUI()
        {
            DestroyItems();
            CreateItems();
        }

        private void CreateItems()
        {
            for (int i = 0; i < _statsData.Length; i++)
            {
                var stat = Instantiate(_statPrefab);

                stat.Init(_statsData[i], _statsData[i].statPowerLevels);

                stat.transform.SetParent(transform);
                stat.transform.localScale = new Vector3(1, 1, 1);
            }
        }

        private void DestroyItems()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }    
}

