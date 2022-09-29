using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{

    private float raycastDist = 30;
    private float itemRaycastDist = 5;

    public Transform camTrans;

    public bool useReticle = false; // option to use reticle
    public bool reticleEnemyChangeColor = false; // option to change reticle color on enemy hover
    public bool reticleItemChangeColor = true; // option to change reticle color on item hover
    private bool reticleOnTarget = false; // check if reticle on enemy or item
    public Transform reticleGroup;
    private Image[] reticleParts;

    private void Awake() {
        reticleParts = reticleGroup.GetComponentsInChildren<Image>();

        if (!useReticle) { // set reticle to inactive if not in use
            (reticleGroup.gameObject).SetActive(false);
        }
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
                    if (item.GetComponent<ItemController>() != null) {
                        item.GetComponent<ItemController>().Use();
                    }

                    // write code for changes after item hit
                }
            }
        }
    }

    private void FixedUpdate() {
        if (useReticle) {
            RaycastHit hit;

            // check if raycast hit an enemy or a close-distanced item
            if (Physics.Raycast(camTrans.position, camTrans.forward, out hit, raycastDist)
                && (hit.collider.CompareTag("Enemy") || (hit.collider.CompareTag("Item") && hit.distance <= itemRaycastDist))) {

                    // change reticle color for enemy
                    if (hit.collider.CompareTag("Enemy") && reticleEnemyChangeColor) {
                        foreach (Image reticlePart in reticleParts) {
                            reticlePart.color = Color.red;
                        }
                    } 
                    // change reticle color for item
                    else if (hit.collider.CompareTag("Item") && reticleItemChangeColor) {
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
}
