using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the masterControlScript

public class masterControl : MonoBehaviour
{
    bool touchControl;
    [Header("UI")]
    [SerializeField] GameObject buttonUI;

    [Header("Script")]
    [SerializeField] buttonControl buttonLogic;
    [SerializeField] wheelController wheelLogic;
    [SerializeField] touchControl touchLogic;
    [SerializeField] trailControl trailLogic;
    void Start()
    {
        setTouchControl();
    }

    public void setTouchControl()
    {
        touchControl = true;
        touchLogic.enabled = true;
        wheelLogic.enabled = true;
        buttonLogic.enabled = false;
        trailLogic.enabled = false;
    }

    public void setButtonControl()
    {
        touchControl = false;
        touchLogic.enabled = false;
        wheelLogic.enabled = false;
        buttonLogic.enabled = true;
        trailLogic.enabled = true;
    }

}
