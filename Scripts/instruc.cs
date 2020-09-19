using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instruc : MonoBehaviour
{
    private bool played = false;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (played == false)
        {
            anim.SetInteger("up", 1);
            played = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (played == true)
        {
            anim.SetInteger("up", 0);
            played = false;
        }
    }
}
