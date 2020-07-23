﻿using UnityEngine;

public class InputController : MonoBehaviour
{
    //следит за пальцем на экране
    public Vector3 TouchPosition;
    public bool DragingStarted = false;
    public Camera CameraForInput;

    private void Start()
    {
        TouchPosition = new Vector3(0, 0);
    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                DragingStarted = true;
                TouchPosition = CameraForInput.ScreenToWorldPoint(touch.position);
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                TouchPosition = CameraForInput.ScreenToWorldPoint(touch.position);
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                DragingStarted = false;
            }
        }
        else
        {
            DragingStarted = false;
        }
        //Debug.Log(TouchPosition);
    }
}
