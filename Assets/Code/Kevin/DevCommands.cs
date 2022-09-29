using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevCommands : MonoBehaviour
{
    public int numZs = 0;
    public GameObject[] objects;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(numZs < 5) {
            if (Input.GetKeyDown(KeyCode.Z)) {
                numZs ++;
                if (numZs == 5) {
                    print("Dev Commands Activated");
                } 
            }
        } else if (Input.GetKeyDown(KeyCode.I)) {
            foreach (GameObject go in objects ) {
                go.SetActive(true);
            }
        } else if (Input.GetKeyDown(KeyCode.O)) {
            player.transform.position = new Vector3(0, 0.5f, 0);
        }
    }
}
