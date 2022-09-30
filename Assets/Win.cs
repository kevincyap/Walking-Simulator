using UnityEngine;

public class Win : MonoBehaviour
{
    public GameUI gameWin;
    public GameObject player;
    public Guard[] guards;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(player);
            for (int i = 0; i < guards.Length; i++)
            {
                Destroy(guards[i]);
            }
            gameWin.ShowGameWinUI();
        }
    }
}
