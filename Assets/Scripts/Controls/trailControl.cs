using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailControl : MonoBehaviour
{
    [SerializeField] GameObject[] wheels;
    [SerializeField] TrailRenderer[] trails;
    [SerializeField] float rotationSpeed;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        foreach (var item in wheels)
        {
            item.transform.Rotate(rotationSpeed * Time.deltaTime, 0f, 0f, Space.Self);
        }
        if (buttonControl.turning)
        {
            foreach (var item in trails)
                item.emitting = true;
        }
        else
        {
            foreach (var item in trails)
                item.emitting = false;
        }
    }
}
