using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallingItems
{
    public class BoostItem : Item
    {
        private string _boostName;
        private float _speed;

        public string boostName => _boostName;

        private void Update()
        {
            Move(_speed);
        }

        public override void Init(float speed, Sprite sprite, string itemName)
        {
            _speed = speed;
            _renderer.sprite = sprite;
            _boostName = itemName;
        }
    }
}

