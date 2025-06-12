using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool sprinting { get; protected set; } = false;
    public float speed = 4;
    float xMove = 0;

    public float jumpForce = 10f;
    public float gravityMultiplier = 5f;
    public Vector2 jumpTime = new Vector2(0.2f, 0.5f);

    protected Rigidbody rb;
    CharacterController controller;

    public LayerMask groundLayer;
    protected bool grounded;

    protected virtual void Start()
    {
        controller = GetComponent<CharacterController>();
        //rb = GetComponent<Rigidbody>();

        land += Land;
        move += Move;
    }

    private void FixedUpdate()
    {
        float yMove = gravityMultiplier;

        Vector3 movement = new(speed * xMove * Time.fixedDeltaTime, yMove * Time.fixedDeltaTime);
        //Add boosted movemenet

        controller.Move(new Vector3(speed * xMove * Time.fixedDeltaTime, yMove * Time.fixedDeltaTime));
        /*
        grounded = Physics.Raycast(transform.position + new Vector3(0, 0.2f, 0), Vector3.down, 0.4f, groundLayer);

        if (!grounded)
            rb.AddForce(Physics.gravity * gravityMultiplier * Time.fixedDeltaTime, ForceMode.Impulse);
        */
    }

    private void Update()
    {
        MovementInput();

        CheckGroundedOrLanded();

        //if (Input.GetButtonDown("Jump") && grounded)
        //{
        //    Debug.Log("Jump start");
        //    jumping = true;
        //    canStopJump = false;
        //    Invoke("EnableStopJump", jumpTime.x);
        //    Invoke("ForceStopJump", jumpTime.y);
        //}

        //if (canStopJump && !Input.GetButton("Jump"))
        //{
        //    ForceStopJump();
        //}
    }

    private void MovementInput()
    {
        xMove = Input.GetAxis("Horizontal");

        if (!Mathf.Approximately(xMove, 0))
            move();
    }

    private void CheckGroundedOrLanded()
    {
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
    }

    bool ignoreLand = true;

    public delegate void DMessage();
    public DMessage move, land;

    void Move()
    {
        //Empty
    }

    void Land()
    {
        //Empty
    }
}
