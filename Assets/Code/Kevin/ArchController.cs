using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchController : ItemController
{
    public bool portalOpen;
    protected override void Start() {
        base.Start();
        portalOpen = false;
    }
    void OpenPortal() {
        portalOpen = true;
        foreach (Transform child in transform) {
            child.gameObject.SetActive(portalOpen);
        }
    }
    public override void Use() {
        print("hi");
        bool hasItem = InventoryManager.instance.HasItem(item);
        if (hasItem && portalOpen == false) {
            InventoryManager.instance.RemoveItem(item);
            OpenPortal();
        }
    }
}
