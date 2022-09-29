using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AZ_Key : AZ_ItemClass
{
    public AudioClip pickup_key;
    
    public override void interact () {
        // play sfx
        AudioSource playerAud = AZ_PlayerInteraction.audioSrc;
        playerAud.PlayOneShot(pickup_key);

        // update objective
        AZ_ObjectiveVars.key_collected = true;

        destroyItem(); // destroy key from scene
    }
}
