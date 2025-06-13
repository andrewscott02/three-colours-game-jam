using UnityEngine;

public class Bouncer : MonoBehaviour
{
    [SerializeField]
    private LayerMask playerLayers;

    [SerializeField]
    private float bounceStrength = 0.02f;

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
            float impulseStrength = Mathf.Clamp(collision.relativeVelocity.magnitude, bounceMinMax.x, bounceMinMax.y);
            Vector3 direction = -collision.GetContact(0).normal;
            direction *= impulseStrength;

            if (collision.collider.gameObject.TryGetComponent<PlayerController>(out PlayerController controller))
            {
                controller.AddBoostMovement(direction, bounceStrength);
            }
        }
    }

    private bool CheckLayer(int layer)
        => (playerLayers & (1 << layer)) != 0;
}