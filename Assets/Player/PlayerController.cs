using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 30;
    float xMove = 0;

    [SerializeField]
    private float gravityMultiplier = -75f;

    [SerializeField]
    private float boostLoss = 7.5f;

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
        movement += boostMovement;

        controller.Move(movement);

        boostMovement = Vector3.Lerp(boostMovement, Vector3.zero, boostLoss * Time.fixedDeltaTime);
    }

    public void AddBoostMovement(Vector3 direction, float strength)
    {
        boostMovement = direction * strength;
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
