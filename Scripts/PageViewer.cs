using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageViewer : MonoBehaviour
{
    public GameObject front;
    public GameObject back;
    public AudioClip AudioClip;
    public GameObject player;

    public string pageNumber;

    public bool hasGotPage;

    private bool inBounds = false;
    private bool text = false;
    private bool open;

    // Start is called before the first frame update
    void Start()
    {
        front.SetActive(false);
        back.SetActive(false);
        pageNumber = string.Empty;
        hasGotPage = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inBounds && text == false)
        {
            player.GetComponent<charMovement>().interacting = true;
            player.GetComponent<charMovement>().horizontal = 0f;
            open = true;
            AudioSource.PlayClipAtPoint(AudioClip, transform.position);
            front.SetActive(true);
            back.SetActive(false);
            text = true;
        }

        else if (Input.GetKeyDown(KeyCode.E) && text)
        {
            AudioSource.PlayClipAtPoint(AudioClip, transform.position);
            back.SetActive(true);
            front.SetActive(false);
            text = false;
        }

        else if (Input.GetKeyDown(KeyCode.Q) && open)
        {
            open = false;
            hasGotPage = true;
            AudioSource.PlayClipAtPoint(AudioClip, transform.position);
            front.SetActive(false);
            back.SetActive(false);
            text = false;
            player.GetComponent<charMovement>().interacting = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            inBounds = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            inBounds = false;
    }
}
