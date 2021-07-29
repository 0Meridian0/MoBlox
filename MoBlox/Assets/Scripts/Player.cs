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
                if (isHorizontal)
                {
                    point = new Vector3(this.transform.position.x,
                                        this.transform.position.y,
                                        Mathf.Round(hit.point.z));
                }
                else
                {
                    point = new Vector3(Mathf.Round(hit.point.x),
                                        this.transform.position.y,
                                        this.transform.position.z);
                }

                if (Physics.Raycast(transform.position, (point - transform.position).normalized, out RaycastHit hit2, (sizeBox + 1) / 2f) &&
                   (hit2.transform.CompareTag("Border") || hit2.transform.CompareTag("Player") || hit2.transform.CompareTag("Game block")))
                {
                    Debug.DrawRay(transform.position, (point - transform.position).normalized, Color.green, (sizeBox + 1) / 2);
                }
                else
                {
                    this.transform.position = point;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("Player") && other.CompareTag("Finish"))
        {
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
