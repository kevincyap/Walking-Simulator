using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AZ_EnemyClass : MonoBehaviour
{   
    public virtual void damaged () {
        Debug.Log("Enemy being attacked");
    }

    public virtual void destroyEnemy () {
        Debug.Log("Destroying Enemy");
        Destroy(this.gameObject);
    }
}
