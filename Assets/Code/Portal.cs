using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform teleport;
    public GameObject player;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.transform.position = teleport.transform.position;
        }
    }
}
