using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoatTravel : MonoBehaviour
{
    public Waypoint currentWaypoint;
    private Transform target { get { return currentWaypoint.transform; }}
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] WaypointManager waypointManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentWaypoint == null)
        {
            currentWaypoint = waypointManager.startingWaypoint;
        }
        navMeshAgent.SetDestination(target.position);
        if (navMeshAgent.remainingDistance >= navMeshAgent.stoppingDistance)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        currentWaypoint = waypointManager.NextWaypoint(currentWaypoint);
        
    }
}
