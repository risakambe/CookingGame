using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject successMenu;
    public PhotonManager pmanager;
    // Start is called before the first frame update
    void Start()
    {
        successMenu.SetActive(true);
        pmanager.Endthegame();
        Invoke("LoadNextscene", 3f);
    }

    // Update is called once per frame
    void LoadNextscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
