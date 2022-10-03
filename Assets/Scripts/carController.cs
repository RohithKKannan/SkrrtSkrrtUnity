using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class carController : MonoBehaviour
{
    public  LayerMask groundLayer;
    public Rigidbody motorRB;
    public Rigidbody carRB;
    private float moveInput;

    [Header("Speed")]
    private float speed;
    public float forwardSpeed;
    public float reverseSpeed;
    public float turnSpeed;

    [Header("Gravity")]
    public float airDrag;
    public float groundDrag;
    [SerializeField] public bool isCarGrounded;
    public float gravityValue;
    private float turnInput;

    [HideInInspector]
    public bool turning;
    public bool speeding;

    public bool upPressed;
    public bool downPressed;

    [Header("UI Buttons")]
    [SerializeField] ButtonScript upButton;
    [SerializeField] ButtonScript downButton;

    [SerializeField] FixedJoystick horizontalJoystick;
    [SerializeField] FixedJoystick verticalJoystick;

    void Start()
    {
        motorRB.transform.parent = null;
        carRB.transform.parent = null;
    }
    void Update()
    {
        /*
        moveInput = Input.GetAxisRaw("Vertical");
        moveInput = moveInput * forwardSpeed;
        turnInput = Input.GetAxisRaw("Horizontal");
        */

        moveInput = verticalJoystick.Vertical;
        turnInput = horizontalJoystick.Horizontal;

        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");

        if(moveInput > 0){
            speed = forwardSpeed;
        }
        else if(moveInput < 0){
            speed = reverseSpeed;
        }

        if(turnInput > 0.5f || turnInput < -0.5f)
            turning = true;
        else turning = false;

        if(moveInput > 0.7f || moveInput < -0.7f)
            speeding = true;
        else speeding = false;

        transform.position = motorRB.transform.position;

        float newRotation = turnInput * turnSpeed * Time.deltaTime * moveInput;
        transform.Rotate(new Vector3(0, newRotation, 0), Space.World);

        RaycastHit hit;

        isCarGrounded = Physics.Raycast(transform.position, -transform.up, out hit, 1f ,groundLayer);

        transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;

        motorRB.drag = isCarGrounded ? groundDrag : airDrag;
    }
    void FixedUpdate()
    {
        if(isCarGrounded)
        {
            motorRB.AddForce(transform.forward * moveInput * speed, ForceMode.Acceleration); 
        }
        else
        {
            motorRB.AddForce(transform.up * -gravityValue);
        }

        carRB.MoveRotation(transform.rotation);
    }
}
