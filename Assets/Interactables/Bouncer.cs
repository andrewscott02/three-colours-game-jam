using UnityEngine;

public class Bouncer : MonoBehaviour
{
    [SerializeField]
    private LayerMask playerLayers;

    [SerializeField]
    private Vector2 bounceStrength;
    [SerializeField]
    private float bounceLossDuration = 0.8f;

    [SerializeField]
    private Vector2 bounceMinMax;

    private void OnCollisionEnter(Collision collision)
    {
        CheckCollision(collision);
    }

    private void OnCollisionStay(Collision collision)
    {
        CheckCollision(collision);
    }

    private void CheckCollision(Collision collision)
    {
        if (CheckLayer(collision.collider.gameObject.layer))
        {
            //collision.impulse.magnitude
            //collision.relativeVelocity.magnitude
            float impulseStrength = Mathf.Clamp(collision.impulse.magnitude, bounceMinMax.x, bounceMinMax.y);
            Vector3 direction = -collision.GetContact(0).normal;
            direction *= bounceStrength;
            //direction *= impulseStrength;

            if (collision.collider.gameObject.TryGetComponent<PlayerController>(out PlayerController controller))
            {
                controller.AddBoostMovement(direction, impulseStrength, bounceLossDuration);
            }
        }
    }

    private bool CheckLayer(int layer)
        => (playerLayers & (1 << layer)) != 0;
}