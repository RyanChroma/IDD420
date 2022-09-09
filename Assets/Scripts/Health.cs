using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [field:SerializeField] public float health { get; private set; }
    [SerializeField] private UnityEvent onDeathEvent;
    public Action<float> onHealthChangeFloat;
    public Action onHealthChange;

    public void DoDamage(float _damage)
    {
        health -= _damage;

        onHealthChangeFloat?.Invoke(health);
        onHealthChange?.Invoke();

        if(health <= 0)
        {
            onDeathEvent.Invoke();
        }
    }
}
