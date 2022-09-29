using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AZ_ObjectiveManager : MonoBehaviour
{
    public int num_collectibles = 0;
    private int total_collectibles = 5;

    public bool checkCollectiblesComplete() {
        return num_collectibles == total_collectibles;
    }

    public void incrementCollectibles() {
        num_collectibles++;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
