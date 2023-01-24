using System;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public event Action<FallingItems.DefaultItem> OnItemTouchGroundEvent;

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
        if (col.collider.TryGetComponent(out FallingItems.DefaultItem item))
        {
            OnItemTouchGroundEvent?.Invoke(item);
        }
    }

    private void DeactivateItem(FallingItems.Item item)
    {
        SoundInvoker.instance.PlayItemHitGroundClip();
        item.gameObject.SetActive(false);
    }

    private void GiveDamage(FallingItems.DefaultItem item)
    {
        playerLifebar.DecreaceHealth(item);
    }
}
