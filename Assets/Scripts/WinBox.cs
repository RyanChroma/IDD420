using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBox : MonoBehaviour
{
    public static Action onWin;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onWin?.Invoke();
            
        }

    }
}
