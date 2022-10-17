using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public CarView player;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }
    void SpawnPlayer()
    {
        CarModel carModel = new CarModel();
        CarController carController = new CarController(carModel, player);
    }
}
