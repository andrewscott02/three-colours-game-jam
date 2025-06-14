using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 30;
    float xMove = 0;

    [SerializeField]
    private float gravityMultiplier = -75f;

    private float boostLossCurrentInterval = 0;
    private float boostLossInterval = 0;

    protected Rigidbody rb;
    CharacterController controller;

    protected bool grounded;

    protected virtual void Start()
    {
        controller = GetComponent<CharacterController>();

        land += Land;
        move += Move;
    }

    Vector3 boostMovement;

    private void FixedUpdate()
    {
        float yMove = gravityMultiplier;

        Vector3 movement = new(speed * xMove * Time.fixedDeltaTime, yMove * Time.fixedDeltaTime);

        if (grounded && controller.isGrounded && boostMovement.magnitude > 0)
        {
            movement *= 0.5f;
        }

        movement += boostMovement;

        controller.Move(movement);

        boostLossCurrentInterval += boostLossInterval * Time.fixedDeltaTime;

        boostMovement = Vector3.Lerp(boostMovement, Vector3.zero, boostLossCurrentInterval);

        Vector3 pos = transform.position;
        pos.z = 0;
        transform.position = pos;
    }

    public void AddBoostMovement(Vector3 direction, float strength, float boostLossDuration)
    {
        direction.z = 0;
        boostMovement = direction * strength;
        boostLossInterval = 1 / boostLossDuration;
        boostLossCurrentInterval = 0;
    }

    private void Update()
    {
        MovementInput();

        CheckGroundedOrLanded();
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
