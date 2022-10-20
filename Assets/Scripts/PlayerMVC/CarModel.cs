using UnityEngine;

public class CarModel
{
    private CarController carController;
    public CarTypes carType;
    public Material color;
    public float movementSpeed;
    public float rotationSpeed;
    public CarModel(float _movementSpeed, float _rotationSpeed, CarTypes _carType, Material _color)
    {
        movementSpeed = _movementSpeed;
        rotationSpeed = _rotationSpeed;
        carType = _carType;
        color = _color;
    }
    public void SetCarController(CarController _carController)
    {
        carController = _carController;
    }
}
