using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUI : MonoBehaviour
{
    private void Start()
    {
        GhostCamera.onCamOn += () => transform.gameObject.SetActive(true);
        GhostCamera.onCamOff += () => transform.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        GhostCamera.onCamOn -= () => transform.gameObject.SetActive(true);
        GhostCamera.onCamOff -= () => transform.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
