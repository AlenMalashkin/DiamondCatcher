using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public event Action<FallingItems.Item> OnItemTouchGroundEvent;

    private void OnEnable()
        {
            OnItemTouchGroundEvent += OnItemTouchGround;
        }

        private void OnDisable()
        {
            OnItemTouchGroundEvent -= OnItemTouchGround;
        }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.TryGetComponent(out FallingItems.Item item))
        {
            OnItemTouchGroundEvent.Invoke(item);
        }
    }

    private void OnItemTouchGround(FallingItems.Item item)
    {
        item.gameObject.SetActive(false);
    }
}
