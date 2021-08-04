using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // static int levelNumber;
    // public void LoadScene(int level)
    public void LoadScene(int level)
    {
        LevelManager.Instance.ChosenLevel = level;
        // levelNumber = level;
        SceneManager.LoadScene("MainScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
