using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AZ_DisplayGlass : AZ_EnemyClass
{
    public AudioClip glass_break;

    public override void damaged () {
        Debug.Log("I am a glass being attacked");
        
        // play glass breaking sound effect
        AudioSource playerAud = AZ_PlayerInteraction.audioSrc;
        playerAud.PlayOneShot(glass_break);

        // delete glass
        destroyEnemy();
    }

}
