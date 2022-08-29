using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraShot : MonoBehaviour
{
    public static Action onCamShot;
    private CameraAmmo cameraAmmo;
    private CameraToggle cameraToggle;

    private void Start()
    {
        cameraAmmo = GetComponent<CameraAmmo>();
        cameraToggle = GetComponent<CameraToggle>();
    }

    void Update()
    {
        if (!cameraToggle.camOn) return;
        if (cameraAmmo.flimCount <= 0) return;
        if (Input.GetMouseButtonDown(0))
        {
            onCamShot?.Invoke();
            cameraAmmo.DecreaseAmmo(1);
            print("CamShot");
                
        }

    }
}
