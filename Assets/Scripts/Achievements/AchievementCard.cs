
using System;
using System.Collections;
using System.Collections.Generic;
using Currency;
using UnityEngine;
using UnityEngine.UI;

namespace Achievements
{
    public class AchievementCard : MonoBehaviour
    {
        private Achievement _achievementData;
        
        [SerializeField] private Image _achievementImage;
        [SerializeField] private Image _rewardImage;

        [SerializeField] private Text _descriptionText;

        [SerializeField] private Text _rewardText;

        [SerializeField] private Text _progressText;

        [SerializeField] private Button _claimButton;
        [SerializeField] private GameObject _rewardGO;

        private Bank _bank;
        private ViewAchievements _viewAchievements;

        private void Start()
        {
            _claimButton.onClick.AddListener(ClaimReward);
            
            if (PlayerPrefs.GetInt(_achievementData.savePath, 0) == 3)
            {
                _rewardGO.SetActive(false);
                _claimButton.gameObject.SetActive(false); 
                _rewardText.text = ""; 
                _progressText.text = "Достижение получено";
            }
        }

        public void Init(Achievement achievementData, Bank bank, ViewAchievements viewAchievements)
        {
            _achievementData = achievementData;
            _bank = bank;
            _viewAchievements = viewAchievements;

            _achievementImage.sprite = achievementData.claimResource.sprite;
            _rewardImage.sprite = achievementData.rewardResource.sprite;
            _descriptionText.text = achievementData.description;
            

            _claimButton.interactable = PlayerPrefs.GetInt(achievementData.claimResource.playerPrefsName + "Total")
                                            >= achievementData.claimResourceCount[PlayerPrefs.GetInt(achievementData.savePath, 0)];
                
            _rewardText.text = achievementData.rewardResourceCount[PlayerPrefs.GetInt(achievementData.savePath, 0)].ToString();
            _progressText.text = PlayerPrefs.GetInt(achievementData.claimResource.playerPrefsName + "Total")
                                     + "/"
                                     + achievementData.claimResourceCount[PlayerPrefs.GetInt(achievementData.savePath, 0)];
        }

        private void ClaimReward()
        {
            _bank.AddResource
            (_achievementData.rewardResource.playerPrefsName, 
                _achievementData.rewardResourceCount[PlayerPrefs.GetInt(_achievementData.savePath, 0)]);
            PlayerPrefs.SetInt(_achievementData.savePath, 
                PlayerPrefs.GetInt(_achievementData.savePath, 0) + 1);
            _viewAchievements.UpdateUI();
        }
    }
}