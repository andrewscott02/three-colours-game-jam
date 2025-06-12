using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.UI;
using System;

public class BoostMovement : MonoBehaviour
{
    [SerializeField]
    private LayerMask boostLayers;

    PlayerController controller;

    protected virtual void Start()
    {
        controller = GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");
        if (CheckLayer(other.gameObject.layer))
        {
            controller.AddBoostMovement(Vector3.up, 15f);
        }
    }

    private bool CheckLayer(int layer)
        => (boostLayers & (1 << layer)) != 0;
}