using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallingItems
{
    public class DefaultItem : Item
    {
        [SerializeField] private int _damage;
        private float _speed;
        private Sprite _sprite;
        private string _playerPrefsName;

        public string GetItemPlayerPrefsName => _playerPrefsName;
        public int GetCurrentItemDamage => _damage;

        private void Update()
        {
            Move(_speed);
        }

        public override void Init(float speed, Sprite sprite, int damage, string playerPrefsName)
        {
            _speed = speed;
            _renderer.sprite = sprite;
            _playerPrefsName = playerPrefsName;
            _damage = damage;
        }
    }
}

