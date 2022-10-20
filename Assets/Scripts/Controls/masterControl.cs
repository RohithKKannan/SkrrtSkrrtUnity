using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This is the masterControlScript

public class masterControl : MonoBehaviour
{
    GameObject Player;

    [Header("UI")]
    [SerializeField] Image touch;
    [SerializeField] Image button;

    [Header("Script")]
    [SerializeField] buttonControl buttonLogic;
    [SerializeField] wheelController wheelLogic;
    [SerializeField] touchControl touchLogic;
    [SerializeField] trailControl trailLogic;

    public static bool touchActive;
    void Start()
    {
        if (PlayerPrefs.GetInt("Touch") == 1)
            setTouchControl();
        else
            setButtonControl();
    }

    public void setTouchControl()
    {
        touchActive = true;
        touch.color = Color.green;
        button.color = Color.white;
        PlayerPrefs.SetInt("Touch", 1);
        touchLogic.enabled = true;
        wheelLogic.enabled = true;
        buttonLogic.enabled = false;
        trailLogic.enabled = false;
    }

    public void setButtonControl()
    {
        touchActive = false;
        touch.color = Color.white;
        button.color = Color.green;
        PlayerPrefs.SetInt("Touch", 0);
        touchLogic.enabled = false;
        wheelLogic.enabled = false;
        buttonLogic.enabled = true;
        trailLogic.enabled = true;
    }

}
