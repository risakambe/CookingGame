using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanagerforfrying : MonoBehaviour
{
    public PanController controller;
    public GameObject beginUI;
    public PhotonManager pmanager;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(Startcounting), 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Startcounting()
    {
        controller.gamehasstarted = true;
        beginUI.SetActive(false);
        pmanager.Startthegame();

    }
}
