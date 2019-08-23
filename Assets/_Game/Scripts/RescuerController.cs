using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescuerController : MonoBehaviour
{
    public List<Transform> movementPoints = new List<Transform>();
    private int currentPosition = 1;

    private void OnEnable()
    {
        ButtonInput.OnLeft += OnLeftPressed;
        ButtonInput.OnRight += OnRightPressed;
    }

    private void OnDisable()
    {
        ButtonInput.OnLeft -= OnLeftPressed;
        ButtonInput.OnRight -= OnRightPressed;
    }


    private void Start()
    {
        UpdatePosition();
    }


    private void OnLeftPressed()
    {
        if (currentPosition > 0)
        {
            currentPosition--;
            UpdatePosition();
            //Debug.Log("Moved Left");
        }
    }


    private void OnRightPressed()
    {
        if (currentPosition < movementPoints.Count - 1)
        {
            currentPosition++;
            UpdatePosition();
            //Debug.Log("Moved Right");
        }
    }


    private void UpdatePosition()
    {
        transform.position = movementPoints[currentPosition].position;
    }

}
