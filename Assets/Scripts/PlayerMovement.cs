using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Transform cam;
    private Animator animator;

    private bool grounded;
    private float yForce;
    public Transform groundCheck;
    public LayerMask colliderLayer;

    public float velocidade = 2f;
    public float pulo = 5f;
    private PlayerEffects playerEffects;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        cam = Camera.main.transform;
        playerEffects = GetComponent<PlayerEffects>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movimento = new Vector3(horizontal, 0, vertical);
        movimento = cam.TransformDirection(movimento);
        movimento.y = 0;

        controller.Move(movimento * Time.deltaTime * velocidade);

        if (movimento != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movimento), Time.deltaTime * 10);
        }

        animator.SetBool("isWalking", movimento != Vector3.zero);

        bool wasGrounded = grounded;
        grounded = Physics.CheckSphere(groundCheck.position, 0.3f, colliderLayer);
        animator.SetBool("grounded", grounded);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            yForce = pulo;
            animator.SetTrigger("jump");
        }

        if (yForce > -9.81f)
        {
            yForce += -9.81f * Time.deltaTime;
        }

        controller.Move(new Vector3(0, yForce, 0) * Time.deltaTime);
        playerEffects.FallEffect(grounded, wasGrounded);
        playerEffects.RunEffect(movimento);
    }
}
