using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] private UnityEvent onDeathEvent;


    public void DoDamage(float _damage)
    {
        health -= _damage;

        if(health <= 0)
        {
            onDeathEvent.Invoke();
        }
    }
}
