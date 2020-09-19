using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingForce : MonoBehaviour
{
    private float initThrust;

    // Strength of the force applied to the right and to the left
    public float rightStrength;
    public float leftStrength;

    public float rightInterval;
    public float leftInterval;

    // Multiplier for the force.
    public float thrust;

    private Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        // Right force will be added every set amount of seconds that the user specifies in editor.
        InvokeRepeating("AddRightForce", 0.1f, rightInterval);

        // Left force will be added every set amount of seconds that the user specifies in editor.
        InvokeRepeating("AddLeftForce", 2f, leftInterval);
    }

    void FixedUpdate()
    {
        
    }
    
    void AddRightForce()
    {
        Vector3 rightForce = new Vector3(rightStrength, 0, 0);
        rb.AddRelativeForce(rightForce * thrust);
        //Debug.Log("Added right force");
        rightForce = new Vector3(0, 0);
    }
    void AddLeftForce()
    {
        Vector3 leftForce = new Vector3(-leftStrength, 0, 0);
        rb.AddRelativeForce(leftForce * thrust);
        //Debug.Log("Added left force");
        leftForce = new Vector3(0, 0);
    }


}
