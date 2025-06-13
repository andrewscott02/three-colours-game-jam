using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeColour : MonoBehaviour
{
    [SerializeField]
    private E_Colours defaultColour = E_Colours.Green;

    [SerializeField]
    private Material redMat;
    [SerializeField]
    private Material greenMat;
    [SerializeField]
    private Material blueMat;

    private MeshRenderer playerRenderer;

    private Dictionary<E_Colours, Material> matsByColours;

    private static readonly Dictionary<E_Colours, E_ColourLayerMasks> layerMasksByColours = new()
    {
        {E_Colours.Red, E_ColourLayerMasks.PlayerRed },
        {E_Colours.Green, E_ColourLayerMasks.PlayerGreen },
        {E_Colours.Blue, E_ColourLayerMasks.PlayerBlue },
    };

    private void Start()
    {
        playerRenderer = GetComponent<MeshRenderer>();

        matsByColours = new()
        {
            {E_Colours.Red, redMat },
            {E_Colours.Green, greenMat },
            {E_Colours.Blue, blueMat },
        };

        ChangeColour(defaultColour);
    }

    private void Update()
    {
        CheckColourChange(E_Colours.Red);
        CheckColourChange(E_Colours.Green);
        CheckColourChange(E_Colours.Blue);
    }

    private void CheckColourChange(E_Colours colour)
    {
        if (Input.GetButtonDown($"Change{colour}"))
        {
            ChangeColour(colour);
        }
    }

    private void ChangeColour(E_Colours colour)
    {
        gameObject.layer = LayerMask.NameToLayer(layerMasksByColours[colour].ToString());

        playerRenderer.material = matsByColours[colour];
    }
}