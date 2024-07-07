using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchDetector : MonoBehaviour
{
    private bool isPinching = false;
    private float InitialDistance;
    private float pinchThreshold = 0.01f;
  
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            if (touch0.phase  == TouchPhase.Began || touch1.phase == TouchPhase.Began)
            {
                // record initial distance between two touches
                InitialDistance = Vector2.Distance(touch0.position, touch1.position);
                isPinching= true;
                Debug.Log("you are pinching");

                
            }
            else if (touch0.phase == TouchPhase.Moved || touch1.phase == TouchPhase.Moved)
            {
                if (isPinching)
                {
                    // calculate current distance between the touches
                    float currentDistance= Vector2.Distance(touch0.position, touch1.position);

                    // determine pinch direction
                    if (Mathf.Abs(currentDistance - InitialDistance) > pinchThreshold)
                    {
                        if (currentDistance>InitialDistance)
                        {
                            Debug.Log("Zoom In");
                     
                        }
                        else
                        {
                            Debug.Log("zoom out");
                        }

                        // update initial distance for next touch
                        InitialDistance = currentDistance;
                    }
                }
            }
            else if (touch0.phase==TouchPhase.Ended || touch1.phase==TouchPhase.Ended || touch0.phase == TouchPhase.Canceled || touch1.phase == TouchPhase.Canceled)
            {
                // reset pinching state when any touch ends or is canceled
                isPinching = false;
            }
        }
        
    }
}
