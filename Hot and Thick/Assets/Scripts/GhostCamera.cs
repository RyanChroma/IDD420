using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GhostCamera : MonoBehaviour
{
    public static Action onCamOn;
    public static Action onCamOff;
    public bool camOn;

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) //GetMouseButtonDown(1) means holding down right click.
        {
            onCamOn?.Invoke();
            print("CamOn");
        }
        else if(Input.GetMouseButtonUp(1)) //This is letting go of right click.
        {
            onCamOff?.Invoke();
            print("CamOff");
        }
    }
}
