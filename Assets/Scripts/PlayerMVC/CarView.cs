using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CarView : MonoBehaviour
{
    private CarController carController;
    public Rigidbody rb;
    private float movement;
    private float rotation;
    void Start()
    {

    }
    void Update()
    {
        Movement();

        if (movement != 0)
            carController.Move(movement, 30);
        if (rotation != 0)
            carController.Rotate(rotation, 30);

    }
    public void SetCarController(CarController _carController)
    {
        carController = _carController;
    }
    public Rigidbody GetCarRB()
    {
        return rb;
    }
    private void Movement()
    {
        movement = Input.GetAxis("Vertical");
        rotation = Input.GetAxis("Horizontal");
    }
}
