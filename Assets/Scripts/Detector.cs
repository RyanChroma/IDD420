using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Detector : MonoBehaviour
{
    public static Action onDetect;
    private GameObject player => GameObject.FindGameObjectWithTag("Player");
    private AudioPlayer audioPlayer;
    [SerializeField]private float detectRange;
    private bool isDetected;

    private void Start()
    {
        audioPlayer = GetComponent<AudioPlayer>();
    }

    void Update()
    {
        if (isDetected) return;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, (player.transform.position - transform.position).normalized, out hit, detectRange, LayerMask.GetMask("Player")))
        {
            if (hit.transform.CompareTag("Player"))
            {
                onDetect?.Invoke();
                audioPlayer.playAudio(0);
                audioPlayer.playAudio(1);
                isDetected = true; 
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, (player.transform.position - transform.position).normalized * detectRange);
    }
}
