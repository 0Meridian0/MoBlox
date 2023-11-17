using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] GameObject[] massPrefabs;

    [SerializeField] Text levelText;
    private void Start()
    {
        var loadingLvl = LevelManager.Instance.ChosenLevel;
        Instantiate(massPrefabs[loadingLvl - 1], Vector3.zero, Quaternion.identity);
        levelText.text = "Level " + loadingLvl;
    }

    public void RestartLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
