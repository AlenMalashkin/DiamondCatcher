using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace FallingItems
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private SpriteRenderer _renderer;
        private float _speed;
        private Sprite _sprite;
        private string _playerPrefsName;

        public int GetCurrentItemDamage => _damage;
        public string GetItemPlayerPrefsName => _playerPrefsName;

        public void Init(float speed, Sprite sprite, int damage, string playerPrefsName)
        {
            _speed = speed;
            _renderer.sprite = sprite;
            _playerPrefsName = playerPrefsName;
            _damage = damage;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.Translate(Vector2.down * _speed * Time.deltaTime);
        }
    }
}

