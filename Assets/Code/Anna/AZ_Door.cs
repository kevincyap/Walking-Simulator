using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AZ_Door : AZ_ItemClass
{
    public string levelName = "Scene_KY";
    public AudioClip doorUnlock;
    private float doorUnlockDuration;
    private bool audioPlayed = false;

    private void Awake() {
        doorUnlockDuration = doorUnlock.length;
    }

    public override void interact() {
        int collected = AZ_ObjectiveVars.collectibles;
        int total_collectibles = AZ_ObjectiveVars.total_collectibles;

        // check if all objectives have been fulfilled and not audio played so player can only trigger it once
        if (total_collectibles - collected <= 0 && AZ_ObjectiveVars.key_collected && !audioPlayed) {
            // play sfx
            AudioSource playerAud = AZ_PlayerInteraction.audioSrc;
            playerAud.PlayOneShot(doorUnlock);
            audioPlayed = true;

            // scene transition when audio finishes playing
            StartCoroutine(waitForAudioEnd());
        }
    }

    IEnumerator waitForAudioEnd() {
        yield return new WaitForSeconds(doorUnlockDuration);
        // audio finishes playing
        SceneManager.LoadScene(levelName); // scene transition
    }
}
