using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainElevator : MonoBehaviour
{
    public GameObject on;
    public GameObject off;
    public GameObject pressE;
    public AudioClip beep;
    public AudioSource moving;
    public Collider2D collisionOne;
    public Collider2D collisionTwo;

    public GameObject lightOne;
    public GameObject lightTwo;
    public GameObject lightThree;
    public GameObject lightFour;
    public GameObject lightFive;
    public GameObject lightSix;

    Animator anim;
    bool inBounds;
    int level = 1;
    GameObject player;
    bool played;

    private void Start()
    {
        anim = GetComponent<Animator>();
        on.SetActive(false);
        off.SetActive(true);
        pressE.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inBounds)
        {
            if (lightOne.activeInHierarchy == true && level == 1)
            {
                AudioSource.PlayClipAtPoint(beep, transform.position);
                moving.Play();
                anim.SetInteger("Level", 1);
                level = 2;
            }

            else if (lightOne.activeInHierarchy == true && lightTwo.activeInHierarchy == true && lightThree.activeInHierarchy == true
                && lightFour.activeInHierarchy == true && lightFive.activeInHierarchy == true && lightSix.activeInHierarchy == true && played == false)
            {
                AudioSource.PlayClipAtPoint(beep, transform.position);
                moving.Play();
                anim.SetInteger("Level", 2);
                played = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (lightOne.activeInHierarchy == true && level == 1)
        {
            on.SetActive(true);
            off.SetActive(false);
            pressE.SetActive(true);
        }

        else if (lightOne.activeInHierarchy == true && lightTwo.activeInHierarchy == true && lightThree.activeInHierarchy == true
                && lightFour.activeInHierarchy == true && lightFive.activeInHierarchy == true && lightSix.activeInHierarchy == true && played == false)
        {
            on.SetActive(true);
            off.SetActive(false);
            pressE.SetActive(true);
        }

        else
        {
            on.SetActive(false);
            off.SetActive(true);
            pressE.SetActive(false);
        }
    }

    public void panel(int state)
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (state == 1)
        {
            player.transform.parent = transform;
            collisionOne.enabled = true;
            collisionTwo.enabled = true;
        }

        else if (state == 0)
        {
            collisionOne.enabled = false;
            collisionTwo.enabled = false;
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
