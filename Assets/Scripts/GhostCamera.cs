using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class GhostCamera : MonoBehaviour
{
    private Camera camera;
    public static Action onCamOn;
    public static Action onCamOff;
    public bool camOn;
    [SerializeField] private float zoomIn;
    [SerializeField] private float zoomOut = 60;
    [SerializeField] private float zoomSpeed;

    private void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) //GetMouseButtonDown(1) means holding down right click.
        {
            onCamOn?.Invoke();
            print("CamOn");
            changeCamFov(zoomIn);
        }
        else if(Input.GetMouseButtonUp(1)) //This is letting go of right click.
        {
            onCamOff?.Invoke();
            print("CamOff");
            changeCamFov(zoomOut);
        }
    }

    public  void changeCamFov(float fov)
    {
        DOTween.To(() => camera.fieldOfView, x => camera.fieldOfView = x, fov, zoomSpeed);
    }

    
}
