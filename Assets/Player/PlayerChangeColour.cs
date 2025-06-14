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

    [SerializeField]
    private GameObject backgroundGameObject;
    private MeshRenderer backgroundRenderer;

    private Dictionary<E_Colours, Material> matsByColours;

    public delegate void DChangeColour(E_Colours colour);
    public DChangeColour changeColour;

    private static readonly Dictionary<E_Colours, E_ColourLayerMasks> layerMasksByColours = new()
    {
        {E_Colours.Red, E_ColourLayerMasks.PlayerRed },
        {E_Colours.Green, E_ColourLayerMasks.PlayerGreen },
        {E_Colours.Blue, E_ColourLayerMasks.PlayerBlue },
    };

    private void Start()
    {
        backgroundRenderer = backgroundGameObject.GetComponent<MeshRenderer>();

        matsByColours = new()
        {
            {E_Colours.Red, redMat },
            {E_Colours.Green, greenMat },
            {E_Colours.Blue, blueMat },
        };

        changeColour += ChangeColour;
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
            changeColour(colour);
        }
    }

    private void ChangeColour(E_Colours colour)
    {
        gameObject.layer = LayerMask.NameToLayer(layerMasksByColours[colour].ToString());

        backgroundRenderer.material = matsByColours[colour];
    }
}