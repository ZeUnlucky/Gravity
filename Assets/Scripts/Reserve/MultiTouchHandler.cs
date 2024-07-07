using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTouchHandler : MonoBehaviour
{
    
    
   
    void Update()
    {
        int touchCount = Input.touchCount;
        
        if (touchCount <1)
            return;

        for (int i = 0; i < touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            Debug.Log($"touch {i} - position {touch.position} phase: {touch.phase}");

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Debug.Log($"touch {i} began at {touch.position}");
                    break;
                    
                case TouchPhase.Moved :
                    Debug.Log($"touch {i} moved to {touch.position}");
                    break;
                
                case TouchPhase.Stationary:
                    Debug.Log($"touch {i} is stationary at {touch.position}");
                    break;
                
                case TouchPhase.Canceled:
                    Debug.Log($"touch {i} canceled at {touch.position}");
                    break;
                
                case TouchPhase.Ended:
                    Debug.Log($"touch {i} ended at {touch.position}");
                    break;
            }
        }

    }
}
