using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    E_Scenes levelSelectScene = E_Scenes.LevelSelect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collided with player");
            SceneManager.LoadScene(levelSelectScene.ToString());
        }
    }
}

[System.Serializable]
public enum E_Scenes
{
    MainMenu, LevelSelect,
    Level1, Level2, Level3, Level4, Level5, Level6,
    Level7, Level8
}