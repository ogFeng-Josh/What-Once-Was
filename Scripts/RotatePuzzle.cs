using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RotatePuzzle : MonoBehaviour
{
    // Basically this script should be attached to each button. 
    


    // This script is still a WIP. Here's what I was going for:
    // The puzzleHolder is the game object that will check if the player is within the collider and can access the puzzle.
    // When the player presses E while within the collider, the buttons will pop up which should contain the puzzle pieces.
    // Each time the player clicks a button, it should rotate 90 degs. 
    // Once the number of times the player has clicked mod the target clicks is equal to zero, that should mean the puzzle is in
    // the correct position. The player clicked times should be no more than four unless the angle of rotation is changed. 
    

    // Each update, the script called "RotatePuzzleManager" will retrieve the value of puzzleDone for each piece. Once all 4 pieces are in place,
    // the if statement in that script will resolve to true and the gameObject for indication the puzzle is complete will be activated.
    // If we want to add more functionality to this puzzle, it shouldn't be too hard; I just wasn't sure what we wanted to happen once it's done.

    //private GameObject player;
    // public GameObject puzzleHolder;

    bool playerClicked;

    private bool playerInBounds;

    public Button puzzlePiece1;

    public int clicksTillRight;

    public int playerClickedTimes;

    public bool puzzleDone;
    void Start()
    {
        playerInBounds = false;
        // puzzleHolder.SetActive(false);
        playerClicked = false;
        playerClickedTimes = 0;
        puzzleDone = false;
    }

    void Update()
    {
        if (playerInBounds)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // puzzleHolder.SetActive(true);
                puzzlePiece1.onClick.AddListener(RotatePiece);
            }
        }
        if(playerClicked)
        {
            playerClickedTimes++;
            puzzlePiece1.transform.Rotate(0, 0, 90f);
            
            playerClicked = false;
        }
        if(playerClickedTimes%clicksTillRight == 0)
        {
            puzzleDone = true;
        }
        else
        {
            puzzleDone = false;
        }

    }
    void RotatePiece()
    {
        playerClicked = true;
    }
    

}
