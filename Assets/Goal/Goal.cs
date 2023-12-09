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

            LevelManager.instance.FinishLevel();

            SceneManager.LoadScene(levelSelectScene.ToString());
        }
    }
}