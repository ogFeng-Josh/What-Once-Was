using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle3 : MonoBehaviour
{
    public Camera cameraShake;

    public string code;
    public GameObject puzzleUI;
    public GameObject buttons;
    public AudioClip wrong;
    public AudioClip correct;
    public AudioClip startUp;
    public GameObject ButtonPressed;
    public GameObject MainPanelOn;
    public GameObject MainPanelOff;
    public GameObject pressE;
    public GameObject invalid;
    public GameObject powerOn;
    public GameObject player;

    private bool inBounds;
    private bool back = false;
    private int audioClip;
    private bool completed = false;

    // Start is called before the first frame update
    void Start()
    {
        puzzleUI.SetActive(false);
        buttons.SetActive(false);
        invalid.SetActive(false);
        powerOn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inBounds && back == false && completed == false)
        {
            puzzleUI.SetActive(true);
            buttons.SetActive(true);
            back = true;
            player.GetComponent<charMovement>().interacting = true;
            player.GetComponent<charMovement>().horizontal = 0f;
            StartCoroutine(UserInput());
        }
        else if (Input.GetKeyDown(KeyCode.E) && back)
        {
            back = false;
            puzzleUI.SetActive(false);
            buttons.SetActive(false);
            player.GetComponent<charMovement>().interacting = false;
        }
    }

    IEnumerator UserInput()
    {
        buttonPress bp = ButtonPressed.GetComponent<buttonPress>();
        Animator anim = puzzleUI.GetComponent<Animator>();

        anim.SetBool("play", true);

        while (bp.buttonValue != "Enter")
        {
            yield return null;
        }

        if (bp.inputString == code)
        {
            AudioSource.PlayClipAtPoint(correct, transform.position);
            back = false;
            puzzleUI.SetActive(false);
            buttons.SetActive(false);
            powerOn.SetActive(true);
            yield return new WaitForSeconds(1);
            powerOn.SetActive(false);
            bp.inputString = null;
            bp.buttonValue = null;
            completed = true;
            MainPanelOff.SetActive(false);
            MainPanelOn.SetActive(true);
            pressE.SetActive(false);
            Debug.Log("correct");
            AudioSource.PlayClipAtPoint(startUp, transform.position);
            StartCoroutine(cameraShake.GetComponent<CameraShake>().Shake(1f, 1f));
            player.GetComponent<charMovement>().interacting = false;
        }

        else
        {
            AudioSource.PlayClipAtPoint(wrong, transform.position);
            back = false;
            puzzleUI.SetActive(false);
            buttons.SetActive(false);
            invalid.SetActive(true);
            yield return new WaitForSeconds(1);
            invalid.SetActive(false);
            bp.inputString = null;
            bp.buttonValue = null;
            Debug.Log("wrong");
            player.GetComponent<charMovement>().interacting = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inBounds = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inBounds = false;
    }
}
