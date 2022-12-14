using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeController : ItemController
{
    public bool locked;
    public AudioClip unlockSound;
    protected override void Start() {
        base.Start();
        locked = true;
    }
    void OpenSafe() {
        AudioManager.instance.PlaySound(unlockSound);
        foreach (Transform child in transform) {
            locked = false;
            if (child.gameObject.name == "Item") {
                child.gameObject.SetActive(true);
            } else if (child.gameObject.name != "Base") {
                child.gameObject.SetActive(false);
            } 
        }
        RoomController.stage = 1;
    }
    public override void Use() {
        bool hasItem = InventoryManager.instance.HasItem(item);
        if (hasItem && locked) {
            InventoryManager.instance.RemoveItem(item);
            OpenSafe();
        }
    }
}
