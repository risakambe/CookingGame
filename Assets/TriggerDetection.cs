using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    public PanController controller;
    // Start is called before the first frame update
   public void settrriger()
    {
        controller.canshake = true;
        controller.counter += 1;
    }
}
