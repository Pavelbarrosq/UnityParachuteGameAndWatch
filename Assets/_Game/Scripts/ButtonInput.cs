using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInput : MonoBehaviour
{
    public bool left;
    public delegate void ButtonPressed();
    public static event ButtonPressed OnLeft;
    public static event ButtonPressed OnRight;


    //private void OnMouseDown()
    //{
    //    if (OnLeft != null && left)
    //    {
    //        OnLeft();
    //        Debug.Log("Left Pressed!");
    //    }
    //    else if (OnRight != null)
    //    {
    //        OnRight();
    //        Debug.Log("Right Pressed!");
    //    }
    //}

    private float leftPosition = -0.01f;
    private float rightPosition = 0.01f;

    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Vector3 touchInput = touch.position;
                Vector3 position = Camera.main.ScreenToWorldPoint(touchInput);

                position.z = 0f;

                if (OnLeft != null && position.x <= leftPosition)
                {
                    Debug.Log("Moved Left");
                    OnLeft();
                }
                else if (OnRight != null && position.x >= rightPosition)
                {
                    Debug.Log("Moved Right");
                    OnRight();
                }
            }
            
        }




        //if (Input.touchCount > 0)
        //{
        //    Touch touchInput = Input.GetTouch(0);
        //    Vector3 position = Camera.main.ScreenToWorldPoint(touchInput.position);
        //    position.z = 0f;
            

        //    if (position.x < -0.01)
        //    {
        //        Debug.Log("Moved LEFT");
        //        OnLeft();
        //    } else if (position.x > 0.01)
        //    {
        //        Debug.Log("Moved RIGHT!");
        //        OnRight();
        //    }
        //}
    }
}
