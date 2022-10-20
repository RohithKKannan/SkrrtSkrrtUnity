using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Car
    {
        public CarTypes carType;
        public float movementSpeed;
        public float rotationSpeed;
        public Material color;
    }
    public List<Car> cars;
    public CarView player;
    [Range(0, 2)] public int carIndex;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }
    void SpawnPlayer()
    {
        CarModel carModel = new CarModel(cars[carIndex].movementSpeed, cars[carIndex].rotationSpeed, cars[carIndex].carType, cars[carIndex].color);
        CarController carController = new CarController(carModel, player);
    }
}
