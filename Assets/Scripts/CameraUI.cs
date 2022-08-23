using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUI : MonoBehaviour
{

    private void Start()
    {
        CameraToggle.onCamOn += () => transform.gameObject.SetActive(true);
        CameraToggle.onCamOff += () => transform.gameObject.SetActive(false);

        transform.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CameraToggle.onCamOn -= () => transform.gameObject.SetActive(true);
        CameraToggle.onCamOff -= () => transform.gameObject.SetActive(false);
    }

 
}
