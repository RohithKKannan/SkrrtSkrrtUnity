using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class touchControl : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] CinemachineVirtualCamera cam;
    public LayerMask groundLayer;
    public Rigidbody motorRB;
    public Rigidbody carRB;
    public float turnSpeed = 30f;
    public float speed = 50f;
    Vector3 direction;
    Vector3 localPos;
    Touch touch;
    Ray ray;
    RaycastHit raycastHit;

    [Header("Gravity")]
    public float airDrag;
    public float groundDrag;
    public bool isCarGrounded;
    public float gravityValue;

    public bool turnLeft, turnRight;
    public bool turning;
    private float angle;
    private Vector3 axisToTurnOn;

    bool buttonInput;

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

    void Update()
    {
        turnLeft = false;
        turnRight = false;
        turning = false;

#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
#else
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            ray = Camera.main.ScreenPointToRay(touch.position);
#endif
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.transform.gameObject.layer == 6)
                {
                    direction = motorRB.transform.InverseTransformPoint(raycastHit.point);
                    direction = direction.normalized;

                    if (direction.z < 0.5)
                    {
                        turning = true;
                    }

                    if (direction.z < 0 && direction.x > 0)
                    {
                        turnRight = true;
                        direction.x = 0.9f;
                    }
                    else if (direction.z < 0 && direction.x < 0)
                    {
                        turnLeft = true;
                        direction.x = -0.9f;
                    }

                    transform.Rotate(new Vector3(0, direction.x * turnSpeed * Time.deltaTime, 0), Space.World);
                }
            }
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
