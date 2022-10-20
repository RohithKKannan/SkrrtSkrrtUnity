using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CarView : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    private CarController carController;
    public Rigidbody rb;
    private float movement;
    private float rotation;
    public MeshRenderer[] color;
    void Start()
    {
        cam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        cam.LookAt = gameObject.transform;
        cam.Follow = gameObject.transform;
    }
    void Update()
    {
        Movement();

        if (movement != 0)
            carController.Move(movement, carController.GetMovementSpeed());
        if (rotation != 0)
            carController.Rotate(rotation, carController.GetRotationSpeed());

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
    public void ChangeColor(Material _color)
    {
        for (int i = 0; i < color.Length; i++)
        {
            color[i].material = _color;
        }
    }
}
