using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    // attach this script to the elevator object. Put two colliders on the elevator, one should be the size of the ground and NOT set as trigger.
    // the other collider should be the size of the actual elevator (taller than other one) and it should be set to a trigger.
    // Elevator should also have a Rigidbody 2D  set to Kinematic and collision detection to continuous.

        // Make sure Player has tag "Player"!!

    // from Partum Game Tutorials on Youtube:
    //https://www.youtube.com/watch?v=QcWtcIo78qQ

    enum EleStates { goUp, goDown, PauseState };
    EleStates states;


    // Elevator panel is the text that will pop up when the player is on the elevator. It will let them press a button to go up
    // or a different button to go down.
    public GameObject elevatorPanel;

    // "top" is the top platform or an empty game object. Make sure the z value is the same as the elevator and "bottom" or it might disappear when you play! 
    public Transform top;
    // "bottom" is the bottom platform or an empty game object. Make sure the z value is the same as the elevator and "top" or it might disappear when you play!
    public Transform bottom;

    // "smooth" is the smoothing value. Play around with this value in editor if something doesn't seem right with the movement. 
    public float smooth;

    // Sets the elevator's position
    Vector3 newposition;

    // true if player has contact with elevator
    bool hasRider;

    void Start()
    {
        elevatorPanel.SetActive(false);
        states = EleStates.PauseState;
    }
    void Update()
    {
        // Change the KeyCodes if we need a different input
        if (Input.GetKeyDown(KeyCode.U) && hasRider)
        {
            states = EleStates.goUp;
        }
        if(Input.GetKeyDown(KeyCode.S) && hasRider)
        {
            states = EleStates.goDown;
        }
        FSM();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // sets the text for the instructions on operating the elevator true, makes sure the player's transform
        // is set to the transform of the elevator or else the elevator would move up without the player.
        if (other.CompareTag("Player"))
        {
            elevatorPanel.SetActive(true);
            other.transform.parent = gameObject.transform;
            hasRider = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            elevatorPanel.SetActive(false);
            other.transform.parent = null;
            hasRider = false;
        }
    }


    // This is a simple state machine. It handles the movement of the elevator.
    void FSM()
    {
        if(states == EleStates.goDown)
        {
            newposition = bottom.position;
            transform.position = Vector3.Lerp(transform.position, newposition, smooth * Time.deltaTime);
            
        }
        if (states == EleStates.goUp)
        {
            newposition = top.position;
            transform.position = Vector3.Lerp(transform.position, newposition, smooth * Time.deltaTime);
        }
        if (states == EleStates.PauseState)
        {

        }
    }
}