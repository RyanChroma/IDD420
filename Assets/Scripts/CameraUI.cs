using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUI : MonoBehaviour
{
    [SerializeField] private Transform camUI;
    private void OnEnable()
    {
        CameraToggle.onCamOn += enableUI;
        CameraToggle.onCamOff += disableUI;

    }

    private void OnDisable()
    {
        CameraToggle.onCamOn -= enableUI;
        CameraToggle.onCamOff -= disableUI;
    }

    public void disableUI()
    {
        camUI.gameObject.SetActive(false);
    }

    public void enableUI()
    {
        camUI.gameObject.SetActive(true);
    }

 
}
