using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class buttonControl : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] CinemachineVirtualCamera cam;

    [Header("References")]
    public Rigidbody motorRB;
    public Rigidbody carRB;
    Vector3 direction;

    [Header("Values")]
    [SerializeField] float speed;
    [SerializeField] float turnSpeed;
    [SerializeField] float groundDrag;
    [SerializeField] float airDrag;
    [SerializeField] float gravityValue;
    [SerializeField] LayerMask groundLayer;
    bool isCarGrounded;
    public static bool turning;
    bool turnLeft, turnRight;
    public delegate void TrailActive();
    public static event TrailActive trailSet;

    void OnEnable()
    {
        cam.LookAt = transform;
        cam.Follow = transform;
    }
    void Start()
    {
        motorRB.transform.parent = null;
        carRB.transform.parent = null;
        direction = Vector3.forward;
    }

    public void turningLeft()
    {
        turnLeft = true;
    }
    public void noTurningLeft()
    {
        turnLeft = false;
    }
    public void noTurningRight()
    {
        turnRight = false;
    }
    public void turningRight()
    {
        turnRight = true;
    }

    void Update()
    {
        turning = false;
        if (turnLeft)
        {
            transform.Rotate(new Vector3(0, -1 * turnSpeed * Time.deltaTime, 0), Space.World);
            turning = true;
        }
        else if (turnRight)
        {
            transform.Rotate(new Vector3(0, 1 * turnSpeed * Time.deltaTime, 0), Space.World);
            turning = true;
        }

        //set car body position to that of motor
        transform.position = motorRB.transform.position;

        //check if car is grounded
        isCarGrounded = Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, 1f, groundLayer);

        motorRB.drag = isCarGrounded ? groundDrag : airDrag;
    }

    void FixedUpdate()
    {
        //Moving the motor
        if (isCarGrounded)
        {
            motorRB.AddForce(transform.forward * speed, ForceMode.Acceleration);
        }
        else
        {
            motorRB.AddForce(transform.up * -gravityValue);
        }
        //Rotating car body collider
        carRB.MoveRotation(transform.rotation);
    }
}
