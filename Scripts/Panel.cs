using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attach this script to the main panel object. It will set each light active as each piece is activated.
/// </summary>
public class Panel : MonoBehaviour
{
    // These are all booleans that are changed only in the Cord script, which is attached to each individual level cord.
    // As each piece in each level is activated, their boolean will be set active here, which will turn the respective panel light on.
    public bool isActive1;
    public bool isActive2;
    public bool isActive3;
    public bool isActive4;
    public bool isActive5;
    public bool isActive6;

    // These should contain each light/sprite object that will be activated for each individual cord activated
    public GameObject active1;
    public GameObject active2;
    public GameObject active3;
    public GameObject active4;
    public GameObject active5;
    public GameObject active6;

    // This counts the number of currently active cord objects on the panel.
    public int switchCounter;

    // This boolean will be set true if the player has all of the pieces activated and has gone back to the main panel
    public bool playerInBounds;

    // This gameobject will be set active when the player has activated all of the cord pieces and is within bounds of panel
    public GameObject pressEInteract;

    // This will be set to true once the player has activated each cord.
    public bool cordDone;

    void Start()
    {
        cordDone = false; 

        isActive1 = false;
        isActive2 = false;
        isActive3 = false;
        isActive4 = false;
        isActive5 = false;
        isActive6 = false;

        active1.gameObject.SetActive(false);
        active2.gameObject.SetActive(false);
        active3.gameObject.SetActive(false);
        active4.gameObject.SetActive(false);
        active5.gameObject.SetActive(false);
        active6.gameObject.SetActive(false);

        switchCounter = 0;

    }

    void Update()
    {
        // These if statements check if each individual cord is active (that is set in each individual cord script)
        // and set each light object on the panel to active as well as counting up the number of activated cord objects.
        // When the cord active counter (switchCounter) hits 6, a message will print to the console saying "Won game".
        if(isActive1 == true)
        {
            active1.SetActive(true);
            switchCounter++;
        }
        if (isActive2 == true)
        {
            active2.SetActive(true);
            switchCounter++;
        }
        if (isActive3 == true)
        {
            active3.SetActive(true);
            switchCounter++;
        }
        if (isActive4 == true)
        {
            active4.SetActive(true);
            switchCounter++;
        }
        if (isActive5 == true)
        {
            active5.SetActive(true);
            switchCounter++;
        }
        if (isActive6 == true)
        {
            active6.SetActive(true);
            switchCounter++;
        }
        if (switchCounter == 6 && playerInBounds && Input.GetKey(KeyCode.E))
        {
            // WinGame();
            cordDone = true;
            Debug.Log("Won game");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && cordDone == true)
        {
            playerInBounds = true;
            pressEInteract.SetActive(true);

        }
        
    }

}
