using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public GameObject[] postersPrefabs;
    public GameObject posterLeft;
    public GameObject posterRight;
    public int posterChance;
    void Start() {
        if (posterLeft != null) {
            Destroy(posterLeft);
        } else if (posterRight != null) {
            Destroy(posterRight);
        }
        RollPoster(-1);
        RollPoster(1);
    }
    void RollPoster(int dir) {
        int roll = Random.Range(0, 100);
        if (roll < posterChance && dir == 1 ? posterRight == null : posterLeft == null) {
            int posterIndex = Random.Range(0, postersPrefabs.Length);
            Vector3 pos = transform.forward*0.25f + transform.right * dir * 6;
            GameObject poster = Instantiate(postersPrefabs[posterIndex], transform.position + pos, transform.rotation*Quaternion.Euler(0, 90, 0));
            poster.transform.parent = gameObject.transform;
            if (dir == -1) {
                posterLeft = poster;
            } else {
                posterRight = poster;
            }
        }
    }
}
