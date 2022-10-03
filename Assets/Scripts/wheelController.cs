using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelController : MonoBehaviour
{
    [SerializeField] GameObject[] wheels;
    [SerializeField] TrailRenderer[] trails;
    public float rotationSpeed;

    private touchControl controller;
    private Animator anim;

    [SerializeField] FixedJoystick joystick;
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<touchControl>();
    }

    void Update()
    {
        /*
        float forwardInput = joystick.Vertical;
        float sidewaysInput = joystick.Horizontal;
        foreach (var item in wheels)
        {
            item.transform.Rotate( forwardInput * rotationSpeed * Time.deltaTime, 0f, 0f, Space.Self);
        }

        if(sidewaysInput < -0.5f)
        {
            anim.SetBool("turningLeft", true);
            anim.SetBool("turningRight", false);
        }
        else if(sidewaysInput > 0.5f)
        {
            anim.SetBool("turningRight", true);
            anim.SetBool("turningLeft", false);
        }
        else
        {
            anim.SetBool("turningRight", false);
            anim.SetBool("turningLeft", false);
        }

        if(controller.turning && controller.speeding && controller.isCarGrounded)
        {
            foreach (var item in trails)
            {
                item.emitting = true;
            }
        }
        else
        {
            foreach (var item in trails)
            {
                item.emitting = false;
            }
        }
        */

        foreach (var item in wheels)
        {
            item.transform.Rotate( rotationSpeed * Time.deltaTime, 0f, 0f, Space.Self);
        }

        if(controller.turnLeft)
        {
            anim.SetBool("turningLeft", true);
            anim.SetBool("turningRight", false);
        }
        else if(controller.turnRight)
        {
            anim.SetBool("turningRight", true);
            anim.SetBool("turningLeft", false);
        }
        else
        {
            anim.SetBool("turningLeft", false);
            anim.SetBool("turningRight", false);
        }

        if(controller.turning && controller.isCarGrounded)
        {
            foreach (var item in trails)
            {
                item.emitting = true;
            }
        }
        else
        {
            foreach (var item in trails)
            {
                item.emitting = false;
            }
        }

    }
}
