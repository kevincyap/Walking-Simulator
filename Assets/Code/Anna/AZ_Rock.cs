using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AZ_Rock : AZ_ItemClass
{
    public AudioClip pickup_rock;
    
    public override void interact () {
        Debug.Log("I Am a Rock");

        // allow player to be able to attack (player weaponized with rock)
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        AZ_PlayerInteraction playerInt = player.GetComponent<AZ_PlayerInteraction>();
        playerInt.reticleEnemyChangeColor = true;
        playerInt.canAttack = true;

        // play sfx
        AudioSource playerAud = AZ_PlayerInteraction.audioSrc;
        playerAud.PlayOneShot(pickup_rock);

        destroyItem(); // destroy rock from scene
    }
}
