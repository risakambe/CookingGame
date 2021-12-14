using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndgameIndicator : MonoBehaviour
{
    public ShakeGameManager manager;
    public ShakeDetector detector;
    public PhotonManager pmanager;
    private void OnTriggerEnter(Collider collision)
    {
        detector.gamehasfailed = true;
        pmanager.ResetTheCounter();
        manager.failgame();
        Destroy(collision.gameObject);
    }
}
