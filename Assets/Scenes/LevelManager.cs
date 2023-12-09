using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public int currentLevel;
    public bool[] finishedLevels;

    public LevelSelectButtonManager buttonManager;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);

        finishedLevels = new bool[buttonManager.buttons.Length];

        for (int i = 0; i < finishedLevels.Length; i++)
        {
            finishedLevels[i] = false;
        }
    }

    public void FinishLevel()
    {
        finishedLevels[currentLevel] = true;
    }
}

[System.Serializable]
public enum E_Scenes
{
    MainMenu, LevelSelect,
    Level1, Level2, Level3, Level4, Level5, Level6,
    Level7, Level8, Level9, Level10
}