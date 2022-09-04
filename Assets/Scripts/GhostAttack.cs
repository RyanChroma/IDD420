using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAttack : MonoBehaviour
{
    private GameObject player => GameObject.FindGameObjectWithTag("Player");
    private Health health => GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    [SerializeField] private float attackRange;
    [SerializeField] private float damage;
    [SerializeField] private float attackCooldown;
    private float _attackCooldown;

    private void Start()
    {
        _attackCooldown = attackCooldown;
    }

    void Update()
    {
        attackCooldown -= Time.deltaTime;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, (player.transform.position - transform.position).normalized, out hit, attackRange, LayerMask.GetMask("Player")))
        {
            if (hit.transform.CompareTag("Player"))
            {
                if (attackCooldown <= 0)
                {
                    health.DoDamage(damage);
                    attackCooldown = _attackCooldown;
                }
 
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, (player.transform.position - transform.position).normalized * attackRange);
    }
}
