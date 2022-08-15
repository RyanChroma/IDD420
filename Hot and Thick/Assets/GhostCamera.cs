using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GhostCamera : MonoBehaviour
{
    public static Action onCamOn;
    public static Action onCamOff;
    public bool camOn;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            onCamOn?.Invoke();
            print("CamOn");
        }
        else if(Input.GetMouseButtonUp(1))
        {
            onCamOff?.Invoke();
            print("CamOff");
        }
    }
}
