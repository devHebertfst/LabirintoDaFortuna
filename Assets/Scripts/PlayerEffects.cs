using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    public GameObject landingEffect;
    private Transform groundCheck;
    private Quaternion effectRotation = Quaternion.Euler(-90, 0, 0);

    public AudioClip fallSound;
    public AudioClip footstepSound;
    private AudioSource audioSource;

    public float footstepInterval = 0.4f;
    public float runstepInterval = 0.2f;
    private float nextFootstepTime;


    void Start()
    {
        groundCheck = transform.Find("GroundCheck");
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = fallSound;
    }

    public void FallEffect(bool grounded, bool wasGrounded)
    {
        if (grounded && !wasGrounded)
        {
            Instantiate(landingEffect, groundCheck.position, effectRotation);
            if (audioSource != null && fallSound != null) {
                audioSource.Play();
            }
        }
    }


    public void WalkEffect(Vector3 movimento, bool grounded, bool isRunning)
    {
        if (movimento != Vector3.zero && Time.time >= nextFootstepTime && grounded && !isRunning)
        {
            if (footstepSound != null)
            {
                audioSource.PlayOneShot(footstepSound);
            }
            nextFootstepTime = Time.time + footstepInterval;
        }
    }

    public void RunEffect(Vector3 movimento, bool grounded, bool isRunning)
    {
        if (movimento != Vector3.zero && Time.time >= nextFootstepTime && grounded && isRunning)
        {
            if (footstepSound != null)
            {
                audioSource.PlayOneShot(footstepSound);
            }
            nextFootstepTime = Time.time + runstepInterval;
        }
    }

    


}
