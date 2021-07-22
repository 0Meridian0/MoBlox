using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    //добавить возможность менять ориентацию из префаба
    //выкинуть RigidBody
    [SerializeField] Camera rayCamera;
    [SerializeField] bool isHorizontal = false;

    private bool moveObject = false;
    public RaycastHit hit;
    public Ray ray;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate() //Фиксить ибо не работает!
    {
        if (moveObject)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100))
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
                this.transform.position = point;
                //GetComponent<Rigidbody>().velocity = point; //заменить на transform.position
            }
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
