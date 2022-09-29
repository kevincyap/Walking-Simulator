using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public GameObject PosterPrefab;

    public int posterChance;
    void Start() {
        RollPoster(-1);
        RollPoster(1);
    }
    void RollPoster(int dir) {
        int roll = Random.Range(0, 100);
        if (roll < posterChance) {
            Vector3 pos = transform.forward*0.25f + transform.right * dir * 5;
            GameObject poster = Instantiate(PosterPrefab, transform.position + pos, transform.rotation*Quaternion.Euler(0, 90, 0));
            poster.transform.parent = gameObject.transform;
        }
    }
}
