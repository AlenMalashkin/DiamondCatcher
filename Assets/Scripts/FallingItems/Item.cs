using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace FallingItems
{
    public abstract class Item : MonoBehaviour
    {
        public SpriteRenderer _renderer;

        public virtual void Init(float speed, Sprite sprite, int damage, string playerPrefsName) {}
        public virtual void Init(float speed, Sprite sprite, string itemName) {}
        public virtual void Init(float speed, Sprite sprite, int damage) {}
        public virtual void Init(float speed, Sprite sprite) {}

        public void Move(float speed)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    }
}

