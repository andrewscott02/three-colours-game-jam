using UnityEngine;

public class BoostMovement : MonoBehaviour
{
    [SerializeField]
    private LayerMask playerLayers;

    [SerializeField]
    private float boostStrength;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");
        if (CheckLayer(other.gameObject.layer))
        {
            if(other.gameObject.TryGetComponent<PlayerController>(out PlayerController controller))
            {
                controller.AddBoostMovement(GetDirection(), boostStrength);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Collided");
        if (CheckLayer(other.gameObject.layer))
        {
            if (other.gameObject.TryGetComponent<PlayerController>(out PlayerController controller))
            {
                controller.AddBoostMovement(GetDirection(), boostStrength);
            }
        }
    }

    private bool CheckLayer(int layer)
        => (playerLayers & (1 << layer)) != 0;


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.5f);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(GetDirection() * 5f, 0.5f);
    }

    private Vector3 GetDirection()
    {
        return transform.up;
    }
}