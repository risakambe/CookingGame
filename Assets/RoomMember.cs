using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMember : MonoBehaviour
{
    private static int currentPlayerNum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetPlayerNum(){
        currentPlayerNum ++;
    }

    public void RemovePlayerNum(){
        currentPlayerNum --;
    }

    public int GetPlayerNum(){
        return currentPlayerNum;
    }
}
