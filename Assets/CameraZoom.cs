using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraZoom : MonoBehaviour
{
    private Camera camera;
    [SerializeField] private float zoomInFOV;
    [SerializeField] private float zoomOutFOV = 60;
    [SerializeField] private float zoomSpeed;

    private void Start()
    {
        camera = Camera.main;
    }

    private void OnEnable()
    {
        CameraToggle.onCamOn += () => changeCamFov(zoomInFOV);
        CameraToggle.onCamOff += () => changeCamFov(zoomOutFOV);
    }
    private void OnDisable()
    {
        CameraToggle.onCamOn += () => changeCamFov(zoomInFOV);
        CameraToggle.onCamOff += () => changeCamFov(zoomOutFOV);
    }

    public void changeCamFov(float fov)
    {
        DOTween.To(() => camera.fieldOfView, x => camera.fieldOfView = x, fov, zoomSpeed);
    }
}
