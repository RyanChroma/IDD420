using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCall : MonoBehaviour
{
    public static Action onPlayerDeath;
   public void Dead()
    {
        Cursor.lockState = CursorLockMode.None;
        onPlayerDeath?.Invoke();
    }
}
