using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    public WaypointManager waypointManager;
    public Rigidbody rigidbody;
    public float speed = 10;
    public float waveSpeed = 2;
    public float rowStrength = 10;
    public float maxDistancefromConveyor = 2;
    public float latteralMovement = 0f;

    [Header("Debug only")]
    public bool stopped = false;
    public GameObject conveyor;

    public Waypoint currentWaypoint;
    public Waypoint destinationWaypoint;
    public Vector3 conveyorPosition;

    private Vector3 offset = Vector3.up;
    private Vector3 startPos { get { return currentWaypoint.transform.position; } }
    private Vector3 destPos { get { return destinationWaypoint.transform.position; } }
    // Start is called before the first frame update
    void Start()
    {
        //currentWaypoint = waypointManager.startingWaypoint;
        conveyorPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentWaypoint == null)
        {
            currentWaypoint = waypointManager.startingWaypoint;
            GetNextWaypoint();
        }
        //movement test
        else if(conveyorPosition + Vector3.down == destinationWaypoint.transform.position )
        {
            GetNextWaypoint();
        }
    }
    private void FixedUpdate()
    {
        SetTetherPoint();
        MoveLaterally();
    }

    private void MoveLaterally()
    {
        if(latteralMovement != 0)
        {
            if(Mathf.Abs(transform.position.z - conveyorPosition.z)< maxDistancefromConveyor)
                rigidbody.AddForce(Vector3.forward * latteralMovement * rowStrength, ForceMode.Impulse);
        }
    }

    private void SetTetherPoint()
    {
        if(Vector3.Distance(transform.position, conveyorPosition) > 0.1f)
        {
            transform.LookAt(conveyorPosition);
            if(Mathf.Abs(transform.position.x - conveyorPosition.x) > 1)
            {
                rigidbody.AddRelativeForce(Vector3.forward * waveSpeed * 2, ForceMode.Force);
            }
            rigidbody.AddRelativeForce(Vector3.forward * waveSpeed, ForceMode.Force);
        }
    }

    public void Move(Vector3 resistance)
    {
        if (!stopped && currentWaypoint != null)
        {
            moveConveyor(resistance.x);
            latteralMovement = resistance.z;
            
        }
    }
    void GetNextWaypoint()
    {
        currentWaypoint = destinationWaypoint;
        destinationWaypoint = waypointManager.NextWaypoint(currentWaypoint);
        if (currentWaypoint == destinationWaypoint)
        {
            stopped = true;
        }
    }
    private void moveConveyor(float drag)
    {
        
        var tempSpeed = speed;
        if (drag != 0)
        {
            Debug.Log(drag);
            tempSpeed = Mathf.Clamp(speed * (Mathf.Sign(drag)*2), .5f, speed * 1.5f);
        }

        float step = tempSpeed * Time.deltaTime;
        conveyorPosition = Vector3.MoveTowards(conveyorPosition, destPos + offset, step);
        conveyor.transform.position = conveyorPosition;
    }

}
