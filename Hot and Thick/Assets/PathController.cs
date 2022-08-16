using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathController : MonoBehaviour
{
    [SerializeField] private List<Transform> wayPoint = new List<Transform>();
    private NavMeshAgent navMeshAgent;
    private int wayPointIndex;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        navMeshAgent.destination = wayPoint[0].position;
    }

    private void Update()
    {
        if(navMeshAgent.remainingDistance <= 0.5f)
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
