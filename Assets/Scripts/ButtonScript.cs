using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public bool pushed;

    public void onPress()
    {
        pushed = true;
    }

    public void onRelease()
    {
        pushed = false;
    }
}
