using UnityEngine;

public class Win : MonoBehaviour
{
    public GameUI gameWin;
    public Guard[] guards;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            for (int i = 0; i < guards.Length; i++)
            {
                Destroy(guards[i]);
            }
            gameWin.ShowGameWinUI();
        }
    }
}
