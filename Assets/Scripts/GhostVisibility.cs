using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostVisibility : MonoBehaviour
{
    [SerializeField] private MeshRenderer renderer;
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        GhostCamera.onCamOn += Visible;
        GhostCamera.onCamOff += Invisible;
    }

    private void OnDisable()
    {
        GhostCamera.onCamOn -= Visible;
        GhostCamera.onCamOff -= Invisible;
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