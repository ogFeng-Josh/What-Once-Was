using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class refocusCam : MonoBehaviour
{
    public GameObject cam;

    private bool inBounds;

    private bool added = false;

    private void Update()
    {
        if (inBounds && added == false)
        {
            cameraFollow2 targets = cam.GetComponent<cameraFollow2>();
            targets.targets.Add(gameObject.transform);
            added = true;

        }

        else if (inBounds == false)
        {
            cameraFollow2 targets = cam.GetComponent<cameraFollow2>();
            targets.targets.Remove(gameObject.transform);
            added = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inBounds = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inBounds = true;
    }
}
