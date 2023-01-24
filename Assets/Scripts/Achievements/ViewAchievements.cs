using System;
using System.Collections;
using System.Collections.Generic;
using Currency;
using UnityEngine;

namespace Achievements
{
    public class ViewAchievements : MonoBehaviour
    {
        [SerializeField] private Achievement[] _achievements;
        [SerializeField] private AchievementCard _achievementCard;
        [SerializeField] private Bank _bank;
        
        private void Awake()
        {
            InitAchievements();
        }

        public void UpdateUI()
        {
            DeleteAchievements();
            InitAchievements();
        }

        private void InitAchievements()
        {
            for (int i = 0; i < _achievements.Length; i++)
            {
                var achievement = Instantiate(_achievementCard, transform, true);

                achievement.Init(_achievements[i], _bank, this);
                achievement.transform.localScale = new Vector3(1, 1, 1);
            }
        }

        private void DeleteAchievements()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}