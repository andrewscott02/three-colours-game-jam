using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool sprinting { get; protected set; } = false;
    public float speed = 4;
    float xMove = 0;

    bool jumping = false;
    bool canStopJump = false;
    public float jumpForce = 10f;
    public float gravityMultiplier = 5f;
    public Vector2 jumpTime = new Vector2(0.2f, 0.5f);
    public float landImpulseStrength = 4f;
    public float landImpulseT = 0.001f;

    protected Rigidbody rb;
    CharacterController controller;

    public LayerMask groundLayer;
    protected bool grounded;

    PlayerSoundwaveManager soundManager;

    protected virtual void Start()
    {
        controller = GetComponent<CharacterController>();
        soundManager = GetComponent<PlayerSoundwaveManager>();
        //rb = GetComponent<Rigidbody>();

        land += Land;
        move += Move;
    }

    private void FixedUpdate()
    {
        float yMove = jumping ? jumpForce : gravityMultiplier;

        controller.Move(new Vector3(speed * xMove * Time.fixedDeltaTime, yMove * Time.fixedDeltaTime));
        /*
        grounded = Physics.Raycast(transform.position + new Vector3(0, 0.2f, 0), Vector3.down, 0.4f, groundLayer);

        if (!grounded)
            rb.AddForce(Physics.gravity * gravityMultiplier * Time.fixedDeltaTime, ForceMode.Impulse);
        */
    }

    private void Update()
    {
        xMove = Input.GetAxis("Horizontal");

        if (!Mathf.Approximately(xMove, 0))
            move();

        if (!grounded && controller.isGrounded)
        {
            if (ignoreLand)
            {
                ignoreLand = false;
            }
            else
            {
                land();
            }
        }

        grounded = controller.isGrounded;

        if (Input.GetButtonDown("Jump") && grounded)
        {
            Debug.Log("Jump start");
            jumping = true;
            canStopJump = false;
            Invoke("EnableStopJump", jumpTime.x);
            Invoke("ForceStopJump", jumpTime.y);
        }

        if (canStopJump && !Input.GetButton("Jump"))
        {
            ForceStopJump();
        }
    }

    void ForceStopJump()
    {
        jumping = false;
        canStopJump = false;
    }

    void EnableStopJump()
    {
        canStopJump = true;
    }

    bool ignoreLand = true;

    void Land()
    {
        //soundManager.Impulse(landImpulseStrength, landImpulseT);
    }

    public delegate void DMessage();
    public DMessage move, land;

    void Move()
    {
        //Empty
    }
}
