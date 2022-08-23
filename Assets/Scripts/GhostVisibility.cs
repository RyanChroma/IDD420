using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostVisibility : MonoBehaviour
{
    [SerializeField] private MeshRenderer renderer;
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        CameraToggle.onCamOn += Visible;
        CameraToggle.onCamOff += Invisible;
    }

    private void OnDisable()
    {
        CameraToggle.onCamOn -= Visible;
        CameraToggle.onCamOff -= Invisible;
    }

    public void Invisible()
    {
        renderer.material.color = new Color32(0, 0, 0, 0);
    }

    public void Visible()
    {
        renderer.material.color = new Color32(255, 255, 255, 255);
    }
}