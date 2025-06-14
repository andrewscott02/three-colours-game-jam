using UnityEngine;
using UnityEngine.UI;

public class LevelSelectButtonManager : MonoBehaviour
{
    public Button[] buttons;

    public Color finishColour = Color.green;
    public Color defaultColour = Color.gray;

    private void Start()
    {
        SetupButtons(LevelManager.instance.finishedLevels);
    }

    public void SetupButtons(bool[] levelStates)
    {
        for (int i = 0; i < levelStates.Length; i++)
        {
            buttons[i].image.color = levelStates[i] ? finishColour : defaultColour;
        }
    }
}
