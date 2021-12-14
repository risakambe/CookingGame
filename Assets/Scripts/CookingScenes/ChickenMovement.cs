using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMovement : MonoBehaviour
{

    private bool gyroEnabled;
    private Gyroscope gyro;
    public GameObject chicken;
    public Quaternion rotation;
    public GameObject chickenMa;
    float Starttime;
    bool pointerNotMoving = true;
    float timeRemaininglose=1.5f;
    float timeRemainingWin = 12f;
    public float timeCounter=0;
    bool tanked = false;
    [SerializeField]
    bool finished = false;
    public float timeslices = 0.5f;
    public float speed;
    public Vector3 axis;
    public RoastChickenManager manager;
    public bool paused;

    void Start()
    {
        gyroEnabled = EnableGyro();
        StartCoroutine(SpeedReckoner(chicken.transform));
    }
    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            chicken.transform.rotation = Quaternion.Euler(0, 0, 0);
            //rotation = new Quaternion(1, 0, 0, 0);
            return true;
        }

        return false;
    }
    // Update is called once per frame
    void Update()
    {
  
        if (gyroEnabled&&!paused)
        {
            chickenMa.GetComponent<MeshRenderer>().material.SetFloat("_Smoothness", timeCounter / timeRemainingWin );
            chicken.transform.Rotate(axis, (float)(-gyro.rotationRate.x*1.5));
            if (speed < 2&&finished==false&&tanked==false)
            {
                Vibration.Vibrate(500);
                timeCounter = 0;
                timeRemaininglose -= Time.deltaTime;
                if (timeRemaininglose <= 0)
                {
                    chickenMa.GetComponent<MeshRenderer>().material.SetFloat("_Metallic", 1);
                    manager.fail();

                }
            }
            if (speed >= 2&&tanked==false&&finished ==false)
            {
                timeRemaininglose = 1.5f; 
                timeCounter += Time.deltaTime;
                //Debug.Log(timeCounter);
                if (timeCounter >= timeRemainingWin)
                {
                    chickenMa.GetComponent<MeshRenderer>().material.SetFloat("_Smoothness", 1f);
                    finished = true;
                    manager.finish();
                }


            }
        }
        

    }

    private IEnumerator SpeedReckoner(Transform target)
    {

        YieldInstruction timedWait = new WaitForSeconds(timeslices);
        float lastrotation = target.rotation.eulerAngles.x;
        float lastTimestamp = Time.time;

        while (enabled)
        {
            yield return timedWait;
            var position = target.rotation.eulerAngles.x;
            var deltaPosition = Mathf .Abs( position - lastrotation);
            var deltaTime = Time.time - lastTimestamp;

            if (Mathf.Approximately(deltaPosition, 0f)) // Clean up "near-zero" displacement
                deltaPosition = 0f;
            if (deltaPosition >100)
                deltaPosition = 100f;

            speed = deltaPosition / deltaTime;
            lastrotation = position;
            lastTimestamp = Time.time;
        }
    }


}
