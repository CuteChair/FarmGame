using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    public static event Action<ItemData> OnPickedUpItem;
    [SerializeField] private ItemData data;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            OnPickedUpItem.Invoke(data);
            Destroy(gameObject);

        }
    }
}
