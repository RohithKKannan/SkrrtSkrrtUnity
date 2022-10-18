using UnityEngine;
using Cinemachine;

public class CarController
{
    private CarModel carModel;
    private CarView carView;
    private Rigidbody rb;
    public CarController(CarModel _carModel, CarView _carView)
    {
        carModel = _carModel;
        carView = GameObject.Instantiate<CarView>(_carView);

        rb = carView.GetCarRB();

        carModel.SetCarController(this);
        carView.SetCarController(this);
    }
    public void Move(float movement, float movementSpeed)
    {
        rb.velocity = carView.transform.forward * movement * movementSpeed;
    }
    public void Rotate(float rotate, float rotationSpeed)
    {
        Vector3 vector = new Vector3(0f, rotate * rotationSpeed, 0f);
        Quaternion deltaRotation = Quaternion.Euler(vector * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

}
