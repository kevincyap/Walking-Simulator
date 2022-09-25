using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{

    private float raycastDist = 30;
    private float itemRaycastDist = 5;

    public Transform camTrans;

    private bool reticleOnTarget = false; // check if reticle on enemy or item

    public Transform reticleGroup;
    private Image[] reticleParts;

    private void Awake() {
        reticleParts = reticleGroup.GetComponentsInChildren<Image>();
    }

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
                else if (hit.collider.CompareTag("Item") && hit.distance <= itemRaycastDist) {
                    GameObject item = hit.collider.gameObject;
                    Debug.Log("Item hit");

                    // write code for changes after item hit
                }
            }
        }
    }

    private void FixedUpdate() {
        RaycastHit hit;

        // check if raycast hit an enemy or a close-distanced item
        if (Physics.Raycast(camTrans.position, camTrans.forward, out hit, raycastDist)
            && (hit.collider.CompareTag("Enemy") || (hit.collider.CompareTag("Item") && hit.distance <= itemRaycastDist))) {

                // change reticle color
                if (hit.collider.CompareTag("Enemy")) {
                    foreach (Image reticlePart in reticleParts) {
                        reticlePart.color = Color.red;
                    }
                } else {
                    foreach (Image reticlePart in reticleParts) {
                        reticlePart.color = Color.cyan;
                    }
                }

                reticleOnTarget = true;

        }
        // otherwise, if reticle is active, reset reticle color
        else if (reticleOnTarget) {
            foreach (Image reticlePart in reticleParts) {
                reticlePart.color = Color.white;
            }

            reticleOnTarget = false;
        }

    }
}
