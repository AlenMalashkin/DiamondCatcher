using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace FallingItems
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private int damage;
        public int GetCurrentItemDamage => damage;
        private bool isMoving;

        private void OnEnable()
        {
            isMoving = true;
        }

        private void OnDisable()
        {
            isMoving = false;
        }

        private void Update()
        {
            if (isMoving)
            {
                Move();
            }
        }

        private void Move()
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    }
}

