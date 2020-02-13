using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatRow : MonoBehaviour
{
    public Vector3 applyForce = Vector3.zero;
    public float maxDistance = 3f;
    [Range(.1f,50f)]public float rowStrength = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Vertical");
        var z = Input.GetAxis("Horizontal");
        if(x!= 0 || z != 0)
        {
            ApplyRow(true, new Vector3(x,0,-z));
        }
        else
        {
            ApplyRow(false, Vector3.zero);
        }
    }
    void ApplyRow(bool rowing, Vector3 direction)
    {
        if (!rowing)
        {
            applyForce = Vector3.zero;
        }
        else
        {

            Vector3 force = (direction * rowStrength);
            applyForce = Vector3.ClampMagnitude(force, maxDistance);
        }
                
    }
}
