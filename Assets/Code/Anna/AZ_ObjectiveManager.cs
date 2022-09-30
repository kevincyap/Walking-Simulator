using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AZ_ObjectiveManager : MonoBehaviour
{
    public TextMeshProUGUI collectibleObj;
    public TextMeshProUGUI keyObj;

    // Start is called before the first frame update
    void Start()
    {
        // init objectives 
        AZ_ObjectiveVars.collectibles = 0;
        AZ_ObjectiveVars.key_collected = false;

        collectibleObj.text = "Steal the collectibles in the displays (" + AZ_ObjectiveVars.collectibles + "/" + AZ_ObjectiveVars.total_collectibles + ")";
    }

    void FixedUpdate() {
        int collected = AZ_ObjectiveVars.collectibles;
        int total_collectibles = AZ_ObjectiveVars.total_collectibles;
        collectibleObj.text = "Steal the collectibles in the displays (" + collected + "/" + total_collectibles + ")";

        // check collectibles all collected and update color
        if (total_collectibles - collected <= 0) {
            collectibleObj.color = Color.green;
        }

        // check key collected and update color
        if (AZ_ObjectiveVars.key_collected) {
            keyObj.color = Color.green;
        }

    }
}
