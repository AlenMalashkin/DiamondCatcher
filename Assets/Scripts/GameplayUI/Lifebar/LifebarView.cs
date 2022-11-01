using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Lifebar
{
    public class LifebarView : MonoBehaviour
    {
        [SerializeField] private PlayerLifebar lifebar;
        [SerializeField] private List<Image> healthPoints;
        [SerializeField] private Image healthPrefab;
        [SerializeField] private Sprite emptyHealthSprite;

        private void OnEnable()
        {
            lifebar.OnIncreasePlayerHealthEvent += IncreaseHealth;
            lifebar.OnDecreasePlayerHealthEvent += DecreaceHealth;

            for (int i = 0; i < lifebar._health; i++)
            {
                var healthSprite = Instantiate(healthPrefab, transform);
                healthPoints.Add(healthSprite);
            }
        }

        private void OnDisable()
        {
            lifebar.OnIncreasePlayerHealthEvent -= IncreaseHealth;
            lifebar.OnDecreasePlayerHealthEvent -= DecreaceHealth;
        }

        private void IncreaseHealth(int health)
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

        private void DecreaceHealth(int health)
        {
            healthPoints[health].sprite = emptyHealthSprite;
        }
    }
}

