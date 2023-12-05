using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool sprinting { get; protected set; } = false;
    public float speed = 4;
    float xMove = 0;

    public float gravityMultiplier = 5f;

    protected Rigidbody rb;
    CharacterController controller;

    public LayerMask groundLayer;
    protected bool grounded;

    protected virtual void Start()
    {
        controller = GetComponent<CharacterController>();
        //rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        controller.Move(new Vector3(speed * xMove * Time.fixedDeltaTime, gravityMultiplier * Time.fixedDeltaTime));
        /*
        grounded = Physics.Raycast(transform.position + new Vector3(0, 0.2f, 0), Vector3.down, 0.4f, groundLayer);

        if (!grounded)
            rb.AddForce(Physics.gravity * gravityMultiplier * Time.fixedDeltaTime, ForceMode.Impulse);
        */
    }

    private void Update()
    {
        xMove = Input.GetAxis("Horizontal");
    }
}
