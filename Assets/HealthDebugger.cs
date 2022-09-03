using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDebugger : MonoBehaviour
{
    Health health => GetComponent<Health>();
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            health.DoDamage(4);
        }
    }
}
