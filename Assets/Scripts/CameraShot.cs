using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraShot : MonoBehaviour
{
    public static Action onCamShot;
    private CameraAmmo cameraAmmo;
    private CameraToggle cameraToggle;
    [SerializeField] private float damage;

    private Camera cam;

    private void Start()
    {
        cameraAmmo = GetComponent<CameraAmmo>();
        cameraToggle = GetComponent<CameraToggle>();

        cam = Camera.main;
    }

    void Update()
    {
        if (!cameraToggle.camOn) return;
        if (cameraAmmo.flimCount <= 0) return;
        if (Input.GetMouseButtonDown(0))
        {
            onCamShot?.Invoke();
            AudioManager.instance.Play("CamLeftClick");
            cameraAmmo.DecreaseAmmo(1);

            RaycastHit hit;
            if(Physics.Raycast(cam.transform.position,cam.transform.forward,out hit,Mathf.Infinity))
            {
                if(hit.transform.TryGetComponent(out Health health))
                {
                    health.DoDamage(damage);
                    AudioManager.instance.Play("ConfirmHit");
                    print("RayDamage");
                }

                print("RayHit");
            }
            print("CamShot");
                
        }

    }
}
