using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpUp : Collectible
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
        playerMovement.pulo *= multiplier;
    }

    protected override void EndEffect()
    {
        playerMovement.pulo /= multiplier;
        cam.m_Lens.FieldOfView = 40f;
    }
}
