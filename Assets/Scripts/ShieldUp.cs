using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUp : Collectible
{
    PlayerMovement playerMovement;

    new void Start(){
        base.Start();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    protected override void StartEffect()
    {
        playerMovement.shieldUp = true;
        gameManager.shieldUpTime = duration;
    }

    protected override void EndEffect()
    {
        playerMovement.shieldUp = false;
    }
}
