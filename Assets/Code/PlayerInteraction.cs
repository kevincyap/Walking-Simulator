using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    private float raycastDist = 30;

    public Transform camTrans;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;

            if (Physics.Raycast(camTrans.position, camTrans.forward, out hit, raycastDist)) {
                // handles raycast for attacking enemies
                if (hit.collider.CompareTag("Enemy")) {
                    GameObject enemy = hit.collider.gameObject;
                    Debug.Log("Enemy hit");

                    // write code for changes after enemy hit
                } 
                // handles raycast for picking up items
                else if (hit.collider.CompareTag("Item") && hit.distance <= 5) {
                    GameObject item = hit.collider.gameObject;
                    Debug.Log("Item hit");

                    // write code for changes after item hit
                }
            }
        }
    }
}
