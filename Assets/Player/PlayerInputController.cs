using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset inputs;

    private PlayerController movementController;
    private PlayerChangeColour colourController;

    public delegate void DChangeControls(bool usingGamepad);
    public DChangeControls changeControls;

    private bool lastusingGamepad = false;

    private void Start()
    {
        movementController = GetComponent<PlayerController>();
        colourController = GetComponent<PlayerChangeColour>();

        ResetInputs();

        inputs.FindAction("Move").performed += MoveInput;
        inputs.FindAction("Move").canceled += MoveInput;

        inputs.FindAction("ChangeRed").performed += ChangeRed;
        inputs.FindAction("ChangeGreen").performed += ChangeGreen;
        inputs.FindAction("ChangeBlue").performed += ChangeBlue;

        inputs.FindAction("Quit").performed += Quit;

        changeControls += InputChanged;
    }

    private void OnDisable()
    {
        ResetInputs();
    }

    private void OnDestroy()
    {
        ResetInputs();
    }

    private void ResetInputs()
    {
        inputs.FindAction("Move").performed -= MoveInput;
        inputs.FindAction("Move").canceled -= MoveInput;

        inputs.FindAction("ChangeRed").performed -= ChangeRed;
        inputs.FindAction("ChangeGreen").performed -= ChangeGreen;
        inputs.FindAction("ChangeBlue").performed -= ChangeBlue;

        inputs.FindAction("Quit").performed -= Quit;
    }

    private void MoveInput(InputAction.CallbackContext context)
    {
        CheckInput(context);
        movementController.MovementInput(context.ReadValue<Vector2>().x);
    }

    private void ChangeRed(InputAction.CallbackContext context)
    {
        colourController.changeColour(E_Colours.Red);
    }

    private void ChangeGreen(InputAction.CallbackContext context)
    {
        colourController.changeColour(E_Colours.Green);
    }

    private void ChangeBlue(InputAction.CallbackContext context)
    {
        colourController.changeColour(E_Colours.Blue);
    }

    private void Quit(InputAction.CallbackContext context)
    {
        inputs.FindAction("Move").performed -= MoveInput;
        inputs.FindAction("Move").canceled -= MoveInput;

        inputs.FindAction("ChangeRed").performed -= ChangeRed;
        inputs.FindAction("ChangeGreen").performed -= ChangeGreen;
        inputs.FindAction("ChangeBlue").performed -= ChangeBlue;

        inputs.FindAction("Quit").performed -= Quit;

        SceneManager.LoadScene("LevelSelect");
    }

    public void CheckInput(InputAction.CallbackContext context)
    {
        bool usingGamepad = context.control.device.name != "Keyboard";

        if (lastusingGamepad != usingGamepad)
        {
            changeControls(usingGamepad);
        }

        lastusingGamepad = usingGamepad;
    }

    private void InputChanged(bool usingGamepad)
    {
        //Do nothing
    }
}