using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AZ_ItemClass : MonoBehaviour
{

    public virtual void interact () {
        Debug.Log("Interacting with item");
    }

    public virtual void destroyItem () {
        Debug.Log("Destroying Item");
        Destroy(this.gameObject);
    }

    public virtual void setInactive () {
        Debug.Log("Deactivating Item");
    }
    
}
