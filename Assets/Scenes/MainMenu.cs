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

    void CloseApplication()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}