using UnityEngine;

public class CarController
{
    private CarModel carModel;
    private CarView carView;
    public GameObject PlayerCar;
    public CarController(CarModel _carModel, CarView _carView)
    {
        carModel = _carModel;
        carView = _carView;

        carModel.SetCarController(this);
        carView.SetCarController(this);

        PlayerCar = GameObject.Instantiate(carView.gameObject);
    }
}
