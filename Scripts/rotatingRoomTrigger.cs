using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingRoomTrigger : MonoBehaviour
{
    public GameObject room;
    public AudioClip noise;

    private bool inBounds = false;

    // Update is called once per frame
    void Update()
    {
        rotatingRoom roomScript = room.GetComponent<rotatingRoom>();
        if (Input.GetKeyDown(KeyCode.E) && inBounds && roomScript.rotating == false)
        {
            StartCoroutine(roomScript.RotateMe(Vector3.forward * 90, 3f));
            AudioSource.PlayClipAtPoint(noise, transform.position, .2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        inBounds = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inBounds = false;
    }
}
