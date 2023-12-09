using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public E_Scenes[] scenes;

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