using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CarView : MonoBehaviour
{
    touchControl touchControl;
    wheelController wheelController;
    buttonControl buttonControl;
    trailControl trailControl;
    private CarController carController;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    public void SetCarController(CarController _carController)
    {
        carController = _carController;
    }
}
