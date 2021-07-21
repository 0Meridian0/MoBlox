using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera rayCamera;
    private bool moveObject = false;
    public RaycastHit hit;
    public Ray ray;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveObject)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100))
            {
                Vector3 point = new Vector3(hit.point.x,
                                        this.transform.position.y,
                                        hit.point.z);
                GetComponent<Rigidbody>().velocity = point;
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
