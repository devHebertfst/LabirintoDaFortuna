using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : Collectible
{
    public float multiplier = 2f;

    public Cinemachine.CinemachineFreeLook cam;
    PlayerMovement playerMovement;

    new void Start(){
        base.Start();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    protected override void StartEffect()
    {
        cam.m_Lens.FieldOfView = 70f;
        playerMovement.velocidade *= multiplier;
        gameManager.speedUpTime = duration;
    }

    protected override void EndEffect()
    {
        playerMovement.velocidade /= multiplier;
        cam.m_Lens.FieldOfView = 40f;
    }
}
