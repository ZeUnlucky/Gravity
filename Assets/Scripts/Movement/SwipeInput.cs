using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeInput : MonoBehaviour
{
    private Vector2 touchPositionStart;
    private Vector2 touchPositionEnd;
    private float swipeThreshold = 50f;
    public static Vector3 moveDirection = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchPositionStart = touch.position;
                    break;

                case TouchPhase.Ended:
                    touchPositionEnd = touch.position;
                    DetectSwipe();
                    break;
            }
        }
        else
            moveDirection = Vector3.zero;
    }

    private void DetectSwipe()
    {
        Vector2 swipeDirection = touchPositionEnd - touchPositionStart;

        if (swipeDirection.magnitude >= swipeThreshold)
        {
            swipeDirection.Normalize();



            if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
            {
                if (swipeDirection.x > 0)
                    moveDirection = Vector3.right;
                else if (swipeDirection.x < 0)
                    moveDirection = Vector3.left;
            }
            else if (Mathf.Abs(swipeDirection.x) < Mathf.Abs(swipeDirection.y))
            {
                if (swipeDirection.y > 0)
                    moveDirection = Vector3.up;

            }
        }
    }
}
