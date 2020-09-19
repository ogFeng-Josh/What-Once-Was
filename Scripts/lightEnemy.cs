//With help from: https://answers.unity.com/questions/384355/stopping-a-raycast-after-hit.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightEnemy : MonoBehaviour
{
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Ground")
            {
                Debug.Log("Hit ground");
            }

            if (hit.collider.tag == "Player")
            {
                Debug.Log("Hit player");
            }
        }
        else
        {
            Debug.Log("No collider hit");
        }

        Debug.DrawRay(transform.position, transform.up * 20, Color.green);
    }
}
