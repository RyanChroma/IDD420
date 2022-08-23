using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraLife : MonoBehaviour
{
    [SerializeField] private float maxLife = 100;
    [field: SerializeField] public float currentLife { get; private set; } = 100;
    [SerializeField] private float drainRate;
    public static Action onLifeOut;
    private bool lifeOut;
    private CameraToggle cameraToggle => GetComponent<CameraToggle>();

    // Update is called once per frame
    void Update()
    {
        if (cameraToggle.camOn)
        {
            currentLife -= drainRate * Time.deltaTime;
        }

        if (!lifeOut && currentLife <= 0)
        {
            onLifeOut?.Invoke();
            lifeOut = true;
            print("Out");
        }

        if (lifeOut && currentLife > 0)
        {
            lifeOut = false;
        }
    }
}
