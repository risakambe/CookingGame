using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeDetector : MonoBehaviour
{

    public float ShakeDetectionThreshold=1;
    public  float Minshakeinterval=0.5f;
    private float timeSinceLasrShake;
    private float sqrShakeThreshold;
    public float effctthreshold;
    public GameObject bottle;
    Gyroscope gyro;
    bool gyroEnabled;
    public float ShakeForceMultiplayer;
    public Rigidbody[] ShakingRigidbody;
    public GameObject yolk;
    public Vector3 axis;
    public float timeslices;
    public float speed;
    public float counterfortotalspeed = 0;
    float  newScale;
    float newBlue;
    public GameObject liquid;
    public bool gamehasfinished = false;
    public ShakeGameManager manager;
    public bool gamehasfailed = false;

    // Start is called before the first frame update
    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            //rotation = new Quaternion(1, 0, 0, 0);
            return true;
        }

        return false;
    }
    void Start()
    {
        sqrShakeThreshold = Mathf.Pow(ShakeDetectionThreshold, 2);
        gyroEnabled = EnableGyro();
        StartCoroutine(SpeedReckoner(yolk.transform));

    }

    public void ShakeRigidBody(Vector3 deviceAcceleration)
    {
        foreach (var rigidbody in ShakingRigidbody)
        {
            rigidbody.AddForce(deviceAcceleration * ShakeForceMultiplayer, ForceMode.Impulse);
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (gyroEnabled&&!gamehasfinished &&!manager.GameisPaused &&!gamehasfailed)
        {
            bottle.transform.Rotate(axis, gyro.rotationRate.z);
            if (Input.acceleration.sqrMagnitude >= sqrShakeThreshold &&
             Time.unscaledTime >= timeSinceLasrShake + Minshakeinterval)
            {
                ShakeRigidBody(Input.acceleration);
                timeSinceLasrShake = Time.unscaledTime;
            }
            newScale = (float)(1 - (0.9 * (counterfortotalspeed / 500)));
            yolk.transform.localScale = new Vector3(newScale, newScale, newScale);
            newBlue = (float)(1 - (0.99 * (counterfortotalspeed / 500)));
            liquid.GetComponent<MeshRenderer>().material.color = new Color(1, 1, newBlue, 0.6f);
            
        }
        






    }
    private IEnumerator SpeedReckoner(Transform target)
    {

        YieldInstruction timedWait = new WaitForSeconds(timeslices);
        Vector3 lastposition = target.position; 
        float lastTimestamp = Time.time;
        

        while (enabled)
        {
            yield return timedWait;
            
            var deltaPosition = (target.position - lastposition).magnitude;
            var deltaTime = Time.time - lastTimestamp;

            if (Mathf.Approximately(deltaPosition, 0f)) // Clean up "near-zero" displacement
                deltaPosition = 0f;
          
            speed = deltaPosition / deltaTime;
            lastposition = target .position ;
            lastTimestamp = Time.time;
            if (counterfortotalspeed <= 500)
            {
                counterfortotalspeed += speed;
                
                
            }
            else
            {
                gamehasfinished = true;
                manager.success();
            }
        }
    }
}
