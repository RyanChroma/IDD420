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
    private bool toggleable = true;

    private void Start()
    {
        CameraLife.onLifeOut += turnOffCam;
        WinBox.onWin -= () => SetToggleable(true);
    }

    private void OnDisable()
    {
        CameraLife.onLifeOut -= turnOffCam;
        WinBox.onWin -= ()=> SetToggleable(false);
    }

    void Update()
    {
        if (!toggleable) return;

        if (Input.GetMouseButtonUp(1)) //This is letting go of right click.
        {
            turnOffCam();
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
            AudioManager.instance.Play("CamRightClick");
            print("CamOn");

        }
  
    }

    public void turnOffCam()
    {
        onCamOff?.Invoke();
        camOn = false;
    }

    public void SetToggleable(bool _toggleable)
    {
        toggleable = _toggleable;
    }

}
