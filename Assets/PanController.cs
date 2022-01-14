using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanController : MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;
    public float ShakeForeceMultiplier;
    public Rigidbody[] ShakingRigidbody;
    public GameObject pan;
    public Vector3 axis;
    public Vector3 force = new Vector3(0, 1, 0);
    public bool canshake = true;
    public Animator anim;
    public float timeslices = 0.5f;
    public float speed;
    public int counter = 0;
    public bool gamehasstarted = false;
    public GameObject successUI;
    public PhotonManager Pmanager;
    // Start is called before the first frame update
    void Start()
    {
        gyroEnabled = EnableGyro();
        pan.transform.rotation = Quaternion.Euler(0, 0, 0);
        

    }
    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            
            return true;
        }

        return false;
    }
    // Update is called once per frame
    public void ShakeRigidbodies(Vector3 deviceAcceleration)
    {
        foreach (var rigibody in ShakingRigidbody)
        {
            rigibody.AddForce(deviceAcceleration * ShakeForeceMultiplier, ForceMode.Impulse);
        }
    }

    public void Loadnextscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static float ClampAngle (float angle, float min, float max)
    {
        
        if (angle<= min&&angle>=180)
        {
            return min;
        }
        if (angle <= min && angle <= 180)
        {
            return max;
        }
        if (angle >= max)
        {
            return max;
        }
        
        else
        {
            return angle;
        }
    }
    

    private void Update()
    {
        
        if (gyroEnabled&&gamehasstarted)
        {
          
            pan.transform.Rotate(axis, gyro.rotationRate.z);
        }
        pan.transform.rotation = Quaternion.Euler(0, 0, ClampAngle(pan.transform.rotation.eulerAngles.z, 270, 360));
       
        if (gyro.rotationRate.z >= 2&&canshake&&gamehasstarted)
        {
            anim.SetTrigger("Jumping");
            canshake = false;
        }
        if (counter >= 15)
        {
            successUI.SetActive(true);
            gamehasstarted = false;
            Pmanager.Endthegame();
            Invoke(nameof(Loadnextscene), 3f);

        }

        
  
        
    }
   
}
