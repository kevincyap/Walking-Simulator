using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AZ_Collectible : AZ_ItemClass
{
    public AudioClip pickup_sfx;

    public override void interact() {
        // play audio
        AudioSource playerAud = AZ_PlayerInteraction.audioSrc;
        playerAud.PlayOneShot(pickup_sfx);

        // update num of collected collectibles in objectives
        AZ_ObjectiveVars.collectibles++;
        
        destroyItem();
    }
}
