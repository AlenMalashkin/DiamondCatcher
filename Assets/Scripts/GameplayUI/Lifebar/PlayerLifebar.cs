using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerUpgradeMenu;
using Scenes;

namespace Lifebar
{
    public class PlayerLifebar : MonoBehaviour
    {
        public Action<int> OnIncreasePlayerHealthEvent;
        public Action<int> OnDecreasePlayerHealthEvent;

        [SerializeField] private int _health;
        [SerializeField] private List<Image> healthPoints;
        [SerializeField] private Image healthPrefab;
        [SerializeField] private Sprite emptyHealthSprite;
        [SerializeField] private StatData[] _stats;
        [SerializeField] private Score _score;

        private Timer.Timer _timer;
        private int _maxHealth;
        private float _regenTime;

        private void Awake()
        {
            _maxHealth = PlayerPrefs.GetInt("maxHealth", 3);
            _regenTime = PlayerPrefs.GetInt("regenTime", 10);
            _health = _maxHealth;

            _timer = new Timer.Timer(_regenTime);
            _timer.Start(_regenTime);
        }

        private void OnEnable()
        {
            OnIncreasePlayerHealthEvent += OnIncreaseHealth;
            OnDecreasePlayerHealthEvent += OnDecreaceHealth;
            _timer.OnTimerFinishedEvent += OnTimerFinished;

            for (int i = 0; i < _maxHealth; i++)
            {
                var healthSprite = Instantiate(healthPrefab, transform);
                healthPoints.Add(healthSprite);
            }
        }

        private void OnDisable()
        {
            OnIncreasePlayerHealthEvent -= OnIncreaseHealth;
            OnDecreasePlayerHealthEvent -= OnDecreaceHealth;
            _timer.OnTimerFinishedEvent -= OnTimerFinished;
        }

        public void IncreaseHealth()
        {
            if (_health < _maxHealth)
            {
                OnIncreasePlayerHealthEvent.Invoke(_health);
                _health += 1;
            }
        }

        public void DecreaceHealth(FallingItems.DefaultItem item)
        {
            _health -= item.GetCurrentItemDamage;
            OnDecreasePlayerHealthEvent.Invoke(_health);
        }

        private void OnIncreaseHealth(int health)
        {
            if (health < healthPoints.Count)
            {
                healthPoints[health].sprite = healthPrefab.sprite;
            }
            else
            {
                healthPoints.Add(Instantiate(healthPrefab, transform));
            }
        }

        private void OnDecreaceHealth(int health)
        {
            if (_health <= 0)
            {
                _health = 0;
                SceneLoader.instance.LoadScene("LoseScreen");
                if (PlayerPrefs.GetFloat(PlayerPrefs.GetString("CurrentLocation")+ "Record", 0) < _score.score)
                    PlayerPrefs.SetFloat(PlayerPrefs.GetString("CurrentLocation") + "Record", _score.score);

                return;
            }

            SoundInvoker.instance.PlayHurtClip();

            for (int i = _maxHealth - 1; i >= health; i--)
            {
                if (healthPoints.Count > 0)
                    healthPoints[i].sprite = emptyHealthSprite;
            }
        }

        private void OnTimerFinished()
        {
            _timer.Start(_regenTime);
            
            if (_maxHealth != _health)
            {
                IncreaseHealth();
            }
        }
    } 
}

