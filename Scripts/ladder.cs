using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ladder : MonoBehaviour
{
    public float speed = 3;
    public GameObject player;

    bool inBounds;

    private void Update()
    {
        if (inBounds)
        {
            if (Input.GetKey(KeyCode.W))
            {
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
                player.GetComponent<Rigidbody2D>().gravityScale = 0;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
                player.GetComponent<Rigidbody2D>().gravityScale = 1;
            }
            else
            {
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                player.GetComponent<Rigidbody2D>().gravityScale = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            inBounds = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inBounds = false;
            collision.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
