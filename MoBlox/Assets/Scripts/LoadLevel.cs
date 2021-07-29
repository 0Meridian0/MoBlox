using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField]
    GameObject[] massPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        int loadingLvl = MakeString();
        Instantiate(massPrefabs[loadingLvl], Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
    int MakeString()
    {
        string _savedLvl = LevelManager.Instance.ChosenLevel();
        int lvl = int.Parse(_savedLvl) - 1;
        return lvl;
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
