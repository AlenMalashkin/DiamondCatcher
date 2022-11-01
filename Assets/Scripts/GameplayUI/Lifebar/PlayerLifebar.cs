using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Lifebar
{
    public class PlayerLifebar : MonoBehaviour
    {
        public Action<int> OnIncreasePlayerHealthEvent;
        public Action<int> OnDecreasePlayerHealthEvent;

        [SerializeField] private Ground ground;
        [SerializeField] private int health;
        public int _health => health;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
                IncreaseHealth();
        }

        private void OnEnable()
        {
            ground.OnItemTouchGroundEvent += DecreaceHealth;
        }

        private void OnDisable()
        {
            ground.OnItemTouchGroundEvent -= DecreaceHealth;
        }

        private void IncreaseHealth()
        {
            if (health < 10)
            {
                OnIncreasePlayerHealthEvent.Invoke(health);
                health += 1;
            }
        }

        public void DecreaceHealth(FallingItems.Item item)
        {
            health -= item.GetCurrentItemDamage;
            OnDecreasePlayerHealthEvent.Invoke(health);
        }
    } 
}

