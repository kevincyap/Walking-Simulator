using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Item item;
    protected virtual void Start() {

    }
    public virtual void Use() {
        if (item.audioClip != null) {
            AudioManager.instance.PlaySound(item.audioClip);
        }
        InventoryManager.instance.AddItem(item);
        Destroy(gameObject);
    }
}
