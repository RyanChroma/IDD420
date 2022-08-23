using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class CameraToggle : MonoBehaviour
{
    public static Action onCamOn;
    public static Action onCamOff;
    public bool camOn { get; private set; }
    private CameraLife cameraLife => GetComponent<CameraLife>();

    private void Start()
    {
        CameraLife.onLifeOut += () => { onCamOff?.Invoke();camOn = false; };
    }

    private void OnDisable()
    {
        CameraLife.onLifeOut -= () => { onCamOff?.Invoke(); camOn = false; };
    }

    void Update()
    {  
        if (Input.GetMouseButtonUp(1)) //This is letting go of right click.
        {
            onCamOff?.Invoke();
            camOn = false;
            print("CamOff");
        }

        if (cameraLife.currentLife <= 0) 
        {
            return;
        } 

        if (Input.GetMouseButtonDown(1)) //GetMouseButtonDown(1) means holding down right click.
        {
            onCamOn?.Invoke();
            camOn = true;
            print("CamOn");

        }
  
    }
}
