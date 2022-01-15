using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutDetector : MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;
    float minPeelInterval = 1f;
    float TimeSinceLastTime=0;
    public GameObject[] slices;
    int counter = 0;
    [SerializeField ]
    bool isCutting = false;
    public Transform initialpos;
    public GameObject nextpotato;
    public GameObject startMenu;
    public PhotonManager pmanager;

    void Start()
    {
        gyroEnabled = EnableGyro();
        if (startMenu != null &&pmanager != null)
        {
            startMenu.SetActive(true);
            Invoke("SetMenufalse", 4f);

        }

    }
    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            //chicken.transform.rotation = Quaternion.Euler(90f, 90f, 0);
            //rotation = new Quaternion(0, 1, 0, 0);
            return true;
        }

        return false;
    }

    private void Update()
    {

        if (gyro.attitude.x > -0.8 && gyro.attitude.x < -0.3 )
        {
            isCutting = true;
        }
        else
        {
            isCutting = true;
        }
        if (-Input.acceleration.y > 4&&Time.unscaledTime >= TimeSinceLastTime + minPeelInterval&& counter < slices.Length - 1&&isCutting)
        {
            Vibration.Vibrate(500);
            FindObjectOfType<AudioManager>().PlaySoundeffect(3);
            
            slices[counter].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            slices[counter].GetComponent<Rigidbody2D>().gravityScale = 3;
            if (counter == slices.Length - 2)
            {
                Invoke("setDynamic", 0.5f);
            }
            
            counter++;
            
            TimeSinceLastTime = Time.unscaledTime;
        }
        if (counter == 4)
        {
            Invoke("generateNextPotato", 2f);
        }
    }
    void generateNextPotato()
    {
        nextpotato.SetActive(true);
    }

    void setDynamic()
    {
        slices[slices.Length - 1].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        slices[slices.Length - 1].GetComponent<Rigidbody2D>().gravityScale = 3;
    }
    void SetMenufalse()
    {
        startMenu.SetActive(false);
        pmanager.Startthegame();
    }
}
