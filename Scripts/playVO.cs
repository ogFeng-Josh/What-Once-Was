using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playVO : MonoBehaviour
{
    public AudioSource AudioClip;
    public GameObject lightOne;
    public GameObject lightTwo;
    public GameObject lightThree;
    public GameObject lightFour;
    public GameObject lightFive;
    public GameObject lightSix;

    private bool played = false;

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(lightSix.activeInHierarchy);
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.name == "VO1")
            {
                if (lightOne.activeInHierarchy == true && played == false)
                {
                    played = true;
                    AudioClip.Play();
                }
            }

            else if (gameObject.name == "VO2")
            {
                if (lightSix.activeInHierarchy == true && lightFive.activeInHierarchy == true && lightFour.activeInHierarchy == true && played == false)
                {
                    played = true;
                    AudioClip.Play();
                }
            }

            else if (gameObject.name == "VO3")
            {
                if (lightTwo.activeInHierarchy == true && lightThree.activeInHierarchy == true && played == false)
                {
                    played = true;
                    AudioClip.Play();
                }
            }
        }

    }
}
