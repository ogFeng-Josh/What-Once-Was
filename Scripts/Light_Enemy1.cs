using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Enemy1 : MonoBehaviour
{
    public GameObject red;
    public GameObject white;
    //public bool inBounds = false;
    public bool stay = false;

    private void Update()
    {
        if (stay)
        {
            red.SetActive(true);
            white.SetActive(false);
        }

       else if (stay == false)
        {
            red.SetActive(false);
            white.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Box" || collision.gameObject.tag == "box")
            stay = true;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Box")
    //        inBounds = true;

private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Box" || collision.gameObject.tag == "box")
            stay = false;
    }
}
