using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombUp : Collectible
{
    public float multiplier = 2f;

    PlayerMovement playerMovement;

    new void Start(){
        base.Start();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    protected override void StartEffect()
    {
        playerMovement.pulo *= multiplier;
        gameManager.bombUpTime = duration;
    }

    protected override void EndEffect()
    {
        playerMovement.pulo /= multiplier;
    }
}
