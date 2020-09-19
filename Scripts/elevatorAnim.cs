using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorAnim : MonoBehaviour
{
    public GameObject on;
    public GameObject off;
    public bool twoLevels = false;
    public GameObject pressE;
    public AudioSource moving;
    public Collider2D collisionOne;
    public Collider2D collisionTwo;

    Animator anim;
    bool inBounds;
    int level = 1;
    GameObject player;
    private bool isMoving;

    private void Start()
    {
        anim = GetComponent<Animator>();
        on.SetActive(true);
        off.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inBounds && level == 1 && isMoving == false)
        {
            moving.Play();
            anim.SetInteger("Level", 1);
            level = 2;
        }

        else if (Input.GetKeyDown(KeyCode.E) && inBounds && level == 2 && isMoving == false)
        {
            moving.Play();
            anim.SetInteger("Level", 2);
            if (twoLevels)
                level = 1;
            else
                level = 3;

        }

        else if (Input.GetKeyDown(KeyCode.E) && inBounds && level == 3 && isMoving == false)
        {
            moving.Play();
            anim.SetInteger("Level", 3);
            level = 1;
        }
    }

    public void panel (int state)
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (state == 0)
        {
            on.SetActive(true);
            off.SetActive(false);
            pressE.SetActive(true);
            isMoving = false;
            collisionOne.enabled = false;
            collisionTwo.enabled = false;
        }
        if (state == 1)
        {
            on.SetActive(false);
            off.SetActive(true);
            player.transform.parent = transform;
            pressE.SetActive(false);
            isMoving = true;
            collisionOne.enabled = true;
            collisionTwo.enabled = true;
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
