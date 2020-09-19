using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recordPlayer : MonoBehaviour
{

    // 1) Add the script to the record art you want
    // 2) Add a Audio Source into the asset WITH the script
    // 3) Add the voice over audio INTO the audio source
    // 4) Drag the audio source from the same asset where the script is located INTO the script's "Voice Over" box
    // 5) Make sure you add a 2D Box Collider and set it as trigger so when the player steps into the area and presses V, it will play!

    bool playerNearby = false;
    AudioSource audioS;
    public AudioClip voiceOver;
 
    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && playerNearby)
        {
            audioS.PlayOneShot(voiceOver);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }

}
