using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AZ_Door : AZ_ItemClass
{
    public string levelName = "Scene_KY";

    public override void interact() {
        int collected = AZ_ObjectiveVars.collectibles;
        int total_collectibles = AZ_ObjectiveVars.total_collectibles;

        // check if all objectives have been fulfilled
        if (total_collectibles - collected <= 0 && AZ_ObjectiveVars.key_collected) {
            // scene transition
            SceneManager.LoadScene(levelName);
        }
    }
}
