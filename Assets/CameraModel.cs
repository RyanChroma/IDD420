using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModel : MonoBehaviour
{
    [SerializeField] private GameObject camModel;
    private bool isShow;
    private void Start()
    {
        isShow = camModel.activeSelf;
    }

    private void OnEnable()
    {
        CameraToggle.onCamOn += showCam;
        CameraToggle.onCamOff += showCam;
    }

    private void OnDisable()
    {
        CameraToggle.onCamOn -= showCam;
        CameraToggle.onCamOff -= showCam;
    }

    public void showCam()
    {
        isShow = !isShow;

        camModel.SetActive(isShow);
    }
}
