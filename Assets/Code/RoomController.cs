using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public GameObject RoomPrefab;
    public GameObject WallPrefab;
    public GameObject LampPrefab;
    public int lampChance;
    public GameObject[] rooms;
    public bool wallsCreated = false;
    private LayerMask envMask;
    private int[,] locations = {{-1, 0}, {1, 0}, {0, -1}, {0, 1}};
    // Start is called before the first frame update
    void Start()
    {
        envMask = LayerMask.GetMask("Environment");
        rooms = new GameObject[24];
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, (transform.localScale / 2), transform.rotation);
        int numRooms = 0;
        for (int i = 0; i < hitColliders.Length; i++) {
            if (hitColliders[i].CompareTag("Room")) {
                numRooms ++;
            }
        }
        if (numRooms > 1) {
            Destroy(gameObject);
        } else {
            RollLamp();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        if (Vector3.Distance(playerPos, transform.position) > 80 ) {
            Destroy(gameObject);
        }
    }

    void RollLamp() {
        int roll = Random.Range(0, 100);
        if (roll < lampChance) {
            GameObject lamp = Instantiate(LampPrefab, transform.position + new Vector3(0, 4.3f, 0), Quaternion.Euler(-90, 0, 0));
        }
    }

    private void createWall(Vector3 pos, Quaternion rot) {
        GameObject wall = Instantiate(WallPrefab, pos, rot);
        wall.transform.parent = gameObject.transform;
    }
    private void createRooms() {
        if (!wallsCreated) {
            wallsCreated = true;
            createWall(transform.position + new Vector3(0, 1.5f, -9.875f), Quaternion.identity);
            createWall(transform.position + new Vector3(0, 1.5f, 9.875f), Quaternion.Euler(0, -180, 0));
            createWall(transform.position + new Vector3(-9.875f, 1.5f, 0), Quaternion.Euler(0, 90, 0));
            createWall(transform.position + new Vector3(9.875f, 1.5f, 0), Quaternion.Euler(0, -90, 0));
        }
        int count = 0;
        for (int x = -2; x <= 2; x++) {
            for (int y = -2; y <= 2; y++) {
                if (rooms[count] == null && (x != 0 || y != 0)) {
                    rooms[count] = Instantiate(RoomPrefab, transform.position + new Vector3(x*20, 0, y*20), Quaternion.identity);
                    count += 1;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            createRooms();
        }
    }
}
