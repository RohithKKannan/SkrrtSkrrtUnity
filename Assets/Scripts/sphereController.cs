using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereController : MonoBehaviour
{
    Rigidbody sphereRB;
    Vector3 direction;
    [SerializeField] float speed = 10f;   
    void Start()
    {
        sphereRB = GetComponent<Rigidbody>();
        direction = Vector3.forward;
    }

    void Update()
    {
        if(Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            //Cast ray from screen point
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            //Save info
            RaycastHit raycastHit;

            //Check if ray hit
            if(Physics.Raycast(ray, out raycastHit))
            {
                direction = (transform.position - raycastHit.point).normalized;
                direction.z *= -1;
                direction.x *= -1;
                Debug.Log(direction);
            }
        }
    }

    void FixedUpdate()
    {
        sphereRB.AddForce(direction * speed, ForceMode.Acceleration);
    }
}
