using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    public GameObject landingEffect;
    private Transform groundCheck;
    private Quaternion effectRotation = Quaternion.Euler(-90, 0, 0);


    void Start()
    {
        groundCheck = transform.Find("GroundCheck");
    }

    public void FallEffect(bool grounded, bool wasGrounded)
    {
        if (grounded && !wasGrounded)
        {
            Instantiate(landingEffect, groundCheck.position, effectRotation);
        }
    }


    public void RunEffect(Vector3 movimento){
        if(movimento!= Vector3.zero){
        }
    }
}
