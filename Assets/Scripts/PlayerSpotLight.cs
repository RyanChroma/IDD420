using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpotLight : MonoBehaviour
{
    [SerializeField] private Light playerLight;
    private bool isOn;

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        CameraToggle.onCamOn += toggleLight;
        CameraToggle.onCamOff += toggleLight;
    }
    private void OnDisable()
    {
        CameraToggle.onCamOn += toggleLight;
        CameraToggle.onCamOff += toggleLight;
    }

    public void toggleLight()
	{
        isOn = !isOn;
        playerLight.enabled = isOn;
	}
}
