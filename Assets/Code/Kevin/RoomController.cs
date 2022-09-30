using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public GameObject RoomPrefab;
    public GameObject WallPrefab;
    public GameObject LampPrefab;
    public GameObject TablePrefab;
    public GameObject KeyPrefab;
    public GameObject SafePrefab;
    public GameObject GatePrefab;
    public int lampChance;
    public int tableChance;
    public int keyChance;
    public int safeChance;
    public int gateChance;
    public GameObject[] rooms;
    public bool wallsCreated = false;
    private LayerMask envMask;
    public bool ranStart = false;

    public static int stage = 0;
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
            if (!wallsCreated) {
                wallsCreated = true;
                createWall(transform.position + new Vector3(0, 1.5f, -9.875f), Quaternion.identity);
                createWall(transform.position + new Vector3(0, 1.5f, 9.875f), Quaternion.Euler(0, -180, 0));
                createWall(transform.position + new Vector3(-9.875f, 1.5f, 0), Quaternion.Euler(0, 90, 0));
                createWall(transform.position + new Vector3(9.875f, 1.5f, 0), Quaternion.Euler(0, -90, 0));
            }
            foreach (Transform child in transform) {
                if (child.gameObject.name != "Floor" && child.gameObject.name != "Ceiling" && !child.gameObject.name.Contains("Wall")) {
                    Destroy(child.gameObject);
                }
            }
            RollObjs();
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
    bool checkSpawnedObjects() {
        foreach (Transform child in transform) {
            if (child.gameObject.name.Contains("Lamp")) {
                return false;
            }
        }
        return true;
    }
    void RollObjs() {
        int roll = Random.Range(0, 100);
        if (stage == 0 && roll < lampChance) {
            GameObject lamp = Instantiate(LampPrefab, transform.position + new Vector3(0, 4.3f, 0), Quaternion.Euler(-90, 0, 0));
            lamp.transform.parent = gameObject.transform;
            int tableRoll = Random.Range(0, 100);
            if (tableRoll < tableChance) {
                GameObject table = Instantiate(TablePrefab, transform.position + new Vector3(0, -1.7f, 0), Quaternion.Euler(0, 0, 0));
                table.transform.parent = gameObject.transform;
                int keyRoll  = Random.Range(0, 100);
                int safeRoll = Random.Range(0, 100);
                if (keyRoll < keyChance) {
                    GameObject key = Instantiate(KeyPrefab, transform.position + new Vector3(0.28f, -0.4f, 0), Quaternion.Euler(0, 0, 0));
                    key.transform.parent = gameObject.transform;
                } else if (safeRoll < safeChance) {
                    GameObject safe = Instantiate(SafePrefab, transform.position + new Vector3(0, 0.1f, 0), Quaternion.Euler(0, 0, 0));
                    safe.transform.parent = gameObject.transform;
                }
            }
            
        } else if (stage == 1 && roll < gateChance) {
            GameObject Gate = Instantiate(GatePrefab, transform.position + new Vector3(0, -1.4f, 0), Quaternion.Euler(0, 0, 0));
        }
    }

    private void createWall(Vector3 pos, Quaternion rot) {
        GameObject wall = Instantiate(WallPrefab, pos, rot);
        wall.transform.parent = gameObject.transform;
    }
    private void createRooms() {
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
