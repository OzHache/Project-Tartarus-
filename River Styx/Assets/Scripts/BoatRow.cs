using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatRow : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
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
        if (rowing)
        {
            rb.velocity = transform.right * (direction.z * rowStrength);
        }
        if(direction.x != 0)
        {
            gameObject.SendMessage("ChangeSpeed", direction.x);
        }
    }
}
