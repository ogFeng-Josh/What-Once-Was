using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attach this script to each individual cord object that should be activated. Make sure each one has a trigger collider.
/// </summary>
public class Cord : MonoBehaviour
{
    
    // This script should be attached to each individual cord object, in each level area. Each cord should be tagged one of the following:
    // "Switch1", "Switch2", "Switch3", "Switch4", "Switch5", or "Switch6"


    public GameObject cordInstruc; // This is the pop-up instructions, such as "E to interact"
    public GameObject cordOff; // This is the cord object when it is turned off
    public GameObject cordConnected; // This is the cord when it is turned on
    public GameObject lightIndiv; // This is the light that is attached to each individual "cord"



    public GameObject panelRef; // This is a reference to the main panel object

    public bool inBounds; // This boolean checks if the player is inside the collider of the individual panel
    
    void Start()
    {
        cordOff.SetActive(true);
        cordConnected.SetActive(false);
        cordInstruc.SetActive(false);
        lightIndiv.SetActive(false);

        
        panelRef = GameObject.FindGameObjectWithTag("Panel");


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inBounds)
        {
            cordConnected.SetActive(true);
            cordOff.SetActive(false);
            lightIndiv.SetActive(true);

            // Each of these if statements will access their respective variable from the main panel's Panel script, setting each active as the player interacts with it.
            if (this.gameObject.CompareTag("Switch1"))
            {
                panelRef.GetComponent<Panel>().isActive1 = true;
            }
            if (this.gameObject.CompareTag("Switch2"))
            {
                panelRef.GetComponent<Panel>().isActive2 = true;
            }
            if (this.gameObject.CompareTag("Switch3"))
            {
                panelRef.GetComponent<Panel>().isActive3 = true;
            }
            if (this.gameObject.CompareTag("Switch4"))
            {
                panelRef.GetComponent<Panel>().isActive4 = true;
            }
            if (this.gameObject.CompareTag("Switch5"))
            {
                panelRef.GetComponent<Panel>().isActive5 = true;
            }
            if (this.gameObject.CompareTag("Switch6"))
            {
                panelRef.GetComponent<Panel>().isActive6 = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cordInstruc.SetActive(true);
            inBounds = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cordInstruc.SetActive(false);
            inBounds = false;
        }
    }
}
