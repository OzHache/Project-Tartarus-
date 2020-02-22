using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatManager : MonoBehaviour
{
    [SerializeField] BoatMovement boatMovement;
    [SerializeField] BoatRow boatRow;
    public static BoatManager GetBoatManager;
    public Vector3 conveyor { get { return boatMovement.conveyorPosition; } }

    // Start is called before the first frame update
    void Start()
    {
        GetBoatManager = this;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
