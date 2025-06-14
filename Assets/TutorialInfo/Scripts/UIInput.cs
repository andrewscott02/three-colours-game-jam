using TMPro;
using UnityEngine;

public class UIInput : MonoBehaviour
{
    private TextMeshProUGUI text;

    [SerializeField]
    private string keyboardText;
    [SerializeField]
    private string controllerText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
        GameObject.FindAnyObjectByType<PlayerInputController>().changeControls += InputChanged;
        InputChanged(false);
    }

    private void InputChanged(bool usingGamepad)
    {
        text.text = usingGamepad ? controllerText : keyboardText;
    }
}
