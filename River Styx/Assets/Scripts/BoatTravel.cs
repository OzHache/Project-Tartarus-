using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoatTravel : MonoBehaviour
{
    public Waypoint currentWaypoint;
    public float speed = 3.5f;

    private Transform target { get { return currentWaypoint.transform; }}

    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] WaypointManager waypointManager;
    public float speedModifier = 0;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDestination();
        if(speedModifier != 0 || (speedModifier == 0 && navMeshAgent.speed != speed)){
            AdjustSpeed();
        }

    }
    void CheckDestination()
    {
        if (currentWaypoint == null)
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

    public void ChangeSpeed(int speed)
    {
        speedModifier = speed;
    }

    void AdjustSpeed()
    {
        //slow down
        if(speedModifier == 0 && navMeshAgent.speed > speed)
        {
            navMeshAgent.speed = speed;

        }
        else
        {
            navMeshAgent.speed = speed + (2*speedModifier)+1;
        }

    }
}
