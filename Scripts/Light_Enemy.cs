using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Enemy : MonoBehaviour
{
    //I used an empty game object for the point from which the ray should be cast.
    public Transform castPoint;

    // distance that the ray will travel
    public float distance;

    public bool hitTarget = false;

    void Update()
    {
        // This gets the position of the cast point
        Vector2 castStart = new Vector2(castPoint.position.x, castPoint.position.y);

        // This casts a ray downward.
        RaycastHit2D hit = Physics2D.Raycast(castStart, -transform.up, distance);

        // Makes sure the ray is hitting something, then checks if the tag is "Player"

        if (hit.collider.CompareTag("Player"))
        {
            hitTarget = true;
        }

        else
        {
            hitTarget = false;
        }
    }
    
}
