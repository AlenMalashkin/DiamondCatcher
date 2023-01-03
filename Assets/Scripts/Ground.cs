using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public event Action<FallingItems.Item> OnItemTouchGroundEvent;

    [SerializeField] private Lifebar.PlayerLifebar playerLifebar;

    private void OnEnable()
        {
            OnItemTouchGroundEvent += DeactivateItem;
            OnItemTouchGroundEvent += GiveDamage;
        }

        private void OnDisable()
        {
            OnItemTouchGroundEvent -= DeactivateItem;
            OnItemTouchGroundEvent -= GiveDamage;
        }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.TryGetComponent(out FallingItems.Item item))
        {
            OnItemTouchGroundEvent.Invoke(item);
        }
    }

    private void DeactivateItem(FallingItems.Item item)
    {
        item.gameObject.SetActive(false);
    }

    private void GiveDamage(FallingItems.Item item)
    {
        playerLifebar.DecreaceHealth(item);
    }
}
