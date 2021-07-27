using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

        //curTetramino = Instantiate(massTetraminoes[Random.Range(0, massTetraminoes.Length)], transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
    int MakeString()
    {
        //обращаемся к сохраненному уровню и получаем 
        int savedLvl = 1;
        string strLvl = "lvl_" + savedLvl;
        return 0;
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
