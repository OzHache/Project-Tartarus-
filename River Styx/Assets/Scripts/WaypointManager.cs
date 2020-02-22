using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    
    [SerializeField] private List<Waypoint> GetWaypoints;
    [SerializeField] private int startingWaypointNumber;
    public Waypoint startingWaypoint { get { return GetWaypoints[startingWaypointNumber]; }}
    
    // Start is called before the first frame update
    void Start()
    {
        
        var children  = GetComponentsInChildren<Waypoint>();
        GetWaypoints.AddRange(children);
        GetWaypoints.Sort(Compare);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private static int Compare(Waypoint x, Waypoint y)
    {
        if (x.waypointNumber == y.waypointNumber)
        {
            Debug.Log(x.gameObject.name + " and " + y.gameObject.name + " have the same waypoint number \nassign a new value to one of these GameObjects");
            return 0;
        }
        else if (x.waypointNumber > y.waypointNumber)
            return 1;
        else
            return -1;
    }
    public Waypoint NextWaypoint(Waypoint after)
    {
        int i = GetWaypoints.IndexOf(after) + 1;
        if(i >= GetWaypoints.Count)
        {
            i--;
        }
        Waypoint next = GetWaypoints[i];

        return next;
    }
    
}
