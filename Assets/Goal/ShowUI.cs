using UnityEngine;

public class ShowUI : MonoBehaviour
{
    public PlayerController moveController;
    public PlayerChangeColour colourController;
    public E_Delegates delegateType;

    public GameObject showElement;

    private void Start()
    {
        switch (delegateType)
        {
            case E_Delegates.move:
                moveController.move += Show;
                break;
            case E_Delegates.land:
                moveController.land += Show;
                break;
            case E_Delegates.changeAny:
            case E_Delegates.changeRed:
            case E_Delegates.changeGreen:
            case E_Delegates.changeBlue:
                colourController.changeColour += CheckColour;
                break;
            default:
                break;
        }
    }

    void CheckColour(E_Colours colour)
    {
        switch (delegateType)
        {
            case E_Delegates.changeAny:
                Show();
                break;
            case E_Delegates.changeBlue:
                if (colour == E_Colours.Blue)
                    Show();
                break;
            case E_Delegates.changeGreen:
                if (colour == E_Colours.Green)
                    Show();
                break;
            case E_Delegates.changeRed:
                if (colour == E_Colours.Red)
                    Show();
                break;
            default:
                break;
        }
    }

    private void OnDestroy()
    {
        switch (delegateType)
        {
            case E_Delegates.move:
                moveController.move -= Show;
                break;
            case E_Delegates.land:
                moveController.land -= Show;
                break;
            case E_Delegates.changeAny:
            case E_Delegates.changeRed:
            case E_Delegates.changeGreen:
            case E_Delegates.changeBlue:
                colourController.changeColour -= CheckColour;
                break;
            default:
                break;
        }
    }

    void Show()
    {
        showElement.SetActive(true);
    }
}

public enum E_Delegates
{
    move, land, changeAny, changeBlue, changeGreen, changeRed,
}