using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDetection : MonoBehaviour
{
    float peelDetectionThreshhold = 1.5f;
    float minPeelInterval = 0.5f;
    float TimeSinceLastTime;
    public GameObject mask;
    public gameManager gamemanager;

    void Update()
    {
        if (Input.acceleration.y >= peelDetectionThreshhold &&
             Time.unscaledTime >= TimeSinceLastTime + minPeelInterval&&gamemanager.GameisPaused == false)
        {
            Debug.Log(Input.acceleration.y);
            Vibration.Vibrate(500);
            mask.transform.Translate(2, 0, 0);
            TimeSinceLastTime = Time.unscaledTime;
        }
    }
}
