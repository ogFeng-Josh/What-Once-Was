using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePuzzleManager : MonoBehaviour
{
    // Put this script on the Puzzle sprite that shows there is a puzzle to be completed. Make sure it has a collider set to trigger.

    public GameObject puzzleHolder; // this should be holding the canvas object that holds the buttons.
    public bool playerInBounds;

    public GameObject instructions;

    public GameObject piece1;
    public GameObject piece2;
    public GameObject piece3;
    public GameObject piece4;

    public bool piece1Done;
    public bool piece2Done;
    public bool piece3Done;
    public bool piece4Done;

    public GameObject puzzleIsDoneIndication;
    public bool puzzleIsDoneCheck;
    // Start is called before the first frame update
    void Start()
    {
        puzzleHolder.SetActive(false);
        playerInBounds = false;
        instructions.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        piece1Done = piece1.GetComponent<RotatePuzzle>().puzzleDone;
        piece2Done = piece2.GetComponent<RotatePuzzle>().puzzleDone;
        piece3Done = piece3.GetComponent<RotatePuzzle>().puzzleDone;
        piece4Done = piece4.GetComponent<RotatePuzzle>().puzzleDone;

        if (piece1Done && piece2Done && piece3Done && piece4Done)
        {
            puzzleIsDoneIndication.SetActive(true);
            puzzleIsDoneCheck = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInBounds = true;
            puzzleHolder.SetActive(true);
            instructions.SetActive(true);
        }
    }

}
