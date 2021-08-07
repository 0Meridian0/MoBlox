using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] Camera rayCamera;
    [SerializeField] bool isHorizontal = false;
    [SerializeField] int sizeBox;

    private bool moveObject = false;
    public Ray ray;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (moveObject)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100))
            {
                Vector3 point;
                float valCord;
                if (isHorizontal)
                {
                    valCord = Mathf.Abs(transform.position.z / 0.5);
                    if (valCord / 2 == 0)
                    {
                        point = new Vector3(transform.position.x, transform.position.y, Mathf.Round(hit.point.z));
                    }
                    else
                    {
                        point = new Vector3(transform.position.x, transform.position.y, Mathf.Round(hit.point.z)+0.5);
                    }
                }
                else
                {
                    valCord = Mathf.Abs(transform.position.x / 0.5);
                    if (valCord / 2 == 0)
                    {
                        point = new Vector3(Mathf.Round(hit.point.x), transform.position.y, transform.position.z);
                    }
                    else
                    {
                        point = new Vector3(Mathf.Round(hit.point.x) + 0.5, transform.position.y, transform.position.z);
                    }
                }

                if (Physics.Raycast(transform.position, (point - transform.position).normalized, out RaycastHit hit2,
                        (sizeBox + 1) / 2f) &&
                    (hit2.transform.CompareTag("Border") || hit2.transform.CompareTag("Player") ||
                     hit2.transform.CompareTag("Game block")))
                {
                    return;
                }
                transform.position = point;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("Player") && other.CompareTag("Finish"))
        {
            LevelManager.Instance.ChosenLevel++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //+ 1);
        }
    }

    void OnMouseDown()
    {
        moveObject = true;
    }

    void OnMouseUp()
    {
        moveObject = false;
    }
}
