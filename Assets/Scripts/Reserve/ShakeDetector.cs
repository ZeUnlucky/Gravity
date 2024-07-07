using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ShakeDetector : MonoBehaviour
{

    public float shakeDetectionThreshold= 2.0f;
    public float minShakeInterval = 0.5f;

    private float lastShakeTime;
    // Start is called before the first frame update
    void Start()
    {
        lastShakeTime = Time.time;
        shakeDetectionThreshold *= shakeDetectionThreshold;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 acceleration = Input.acceleration;

        float accelerationSqrMagnitude = acceleration.sqrMagnitude;

        if (accelerationSqrMagnitude >= shakeDetectionThreshold && Time.time >= lastShakeTime + minShakeInterval) 
        {
            lastShakeTime = Time.time;
            OnShake();
        }
    }

    private void OnShake()
    {
        Debug.Log("device shaked");
    }
}
