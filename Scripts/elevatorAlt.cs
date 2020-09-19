using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorAlt : MonoBehaviour
{
    public Animator elevatorMovement;
    public GameObject instruc;
    private bool inBounds;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inBounds)
        {
            elevatorMovement.Play("ladderUp");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            instruc.SetActive(true);
            inBounds = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            instruc.SetActive(false);
            inBounds = false;
        }
    }
}
