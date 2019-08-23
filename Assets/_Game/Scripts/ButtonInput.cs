using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInput : MonoBehaviour
{
    public bool left;
    public delegate void ButtonPressed();
    public static event ButtonPressed OnLeft;
    public static event ButtonPressed OnRight;


    private void OnMouseDown()
    {
        if (OnLeft != null && left)
        {
            OnLeft();
            Debug.Log("Left Pressed!");
        }
        else if (OnRight != null)
        {
            OnRight();
            Debug.Log("Right Pressed!");
        }
    }
}
