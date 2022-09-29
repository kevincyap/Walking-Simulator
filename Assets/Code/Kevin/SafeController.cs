using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeController : ItemController
{
    public bool locked;
    protected override void Start() {
        base.Start();
        locked = true;
    }
    void OpenSafe() {
        foreach (Transform child in transform) {
            locked = false;
            if (child.gameObject.name != "Base" && child.gameObject.name != "Item") {
                child.gameObject.SetActive(false);
            }
        }
    }
    public override void Use() {
        bool hasItem = InventoryManager.instance.HasItem(item);
        print(hasItem + " " + locked);
        if (hasItem && locked) {
            InventoryManager.instance.RemoveItem(item);
            OpenSafe();
        }
    }
}
