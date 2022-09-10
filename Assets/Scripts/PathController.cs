using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class PathController : MonoBehaviour
{
    [SerializeField] private List<Transform> wayPoint = new List<Transform>();
    private NavMeshAgent navMeshAgent;
    private int wayPointIndex;
    private bool playerDetect;
    private Detector detector => GetComponent<Detector>();

    private void OnEnable()
    {
        detector.onDetect +=  ()=> playerDetect = true;
    }

    private void OnDisable()
    {
        detector.onDetect -= () => playerDetect = true;
    }

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (!wayPoint.All(a => a != null)) return;
        if (wayPoint.Count == 0) return;

        navMeshAgent.destination = wayPoint[0].position;
    }

    private void Update()
    {
        if (playerDetect)
        {
            navMeshAgent.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
            return;
        }

        if (!wayPoint.All(a => a != null)) return;
        if (wayPoint.Count <= 0) return;

        if (navMeshAgent.remainingDistance <= 0.5f)
        {
            wayPointIndex++;

            if(wayPointIndex > wayPoint.Count - 1)
            {
                navMeshAgent.destination = wayPoint[0].position;
                wayPointIndex = 0;
            }
            else
            {
                navMeshAgent.destination = wayPoint[wayPointIndex].position;
            }
        }
    }

}
