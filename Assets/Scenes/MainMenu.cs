using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset inputs;

    public E_Scenes[] scenes;

    public GameObject defaultButton;

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(defaultButton);

        inputs.FindAction("Move").performed += CheckInput;
        inputs.FindAction("Move").canceled += CheckInput;

        inputs.FindAction("ChangeRed").performed += CheckInput;
        inputs.FindAction("ChangeGreen").performed += CheckInput;
        inputs.FindAction("ChangeBlue").performed += CheckInput;

        inputs.FindAction("Quit").performed += CheckInput;
    }

    public void CheckInput(InputAction.CallbackContext context)
    {
        bool usingGamepad = context.control.device.name != "Keyboard";

        if (EventSystem.current != null)
        {
            if (usingGamepad && EventSystem.current.currentSelectedGameObject == null)
            {
                EventSystem.current.SetSelectedGameObject(defaultButton);
            }
        }
    }

    public void LoadScene(int sceneIndex)
    {
        if (sceneIndex < 0 || sceneIndex > scenes.Length)
        {
            CloseApplication();
            return;
        }

        SceneManager.LoadScene(scenes[sceneIndex].ToString());
    }

    public void LoadSceneAsLevel(int sceneIndex)
    {
        if (sceneIndex < 0 || sceneIndex > scenes.Length)
        {
            CloseApplication();
            return;
        }

        Debug.Log("Load level " + (sceneIndex - 1));
        LevelManager.instance.currentLevel = sceneIndex - 1;

        SceneManager.LoadScene(scenes[sceneIndex].ToString());
    }

    public static string webplayerQuitURL = "https://andrewjscott02.itch.io/creak";

    void CloseApplication()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPlayer || UNITY_WEBGL
        Application.OpenURL(webplayerQuitURL);
        #else
        Application.Quit();
        #endif
    }
}