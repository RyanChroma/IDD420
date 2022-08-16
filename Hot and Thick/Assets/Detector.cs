using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Detector : MonoBehaviour
{
    public static Action onDetect;
    private GameObject player => GameObject.FindGameObjectWithTag("Player");
    [SerializeField]private float detectRange;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, (player.transform.position - transform.position).normalized, out hit, detectRange, LayerMask.GetMask("Player")))
        {
            if (hit.transform.CompareTag("Player"))
            {
                onDetect?.Invoke();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, (player.transform.position - transform.position).normalized * detectRange);
    }
}
