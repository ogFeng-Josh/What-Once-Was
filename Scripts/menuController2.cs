using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuController2 : MonoBehaviour
{
    public GameObject menu;
    public GameObject inventory;
    public GameObject instruc;
    public GameObject player;
    public GameObject buttons;

    public GameObject page0;
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public GameObject page4;
    public GameObject page5;
    public GameObject page6;
    public GameObject page7;

    private bool open;
    private GameObject[] pgs;
    private bool interact;
    private bool buttonsOn;

    List<GameObject> activePgs = new List<GameObject>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && open == false)
        {
            if (player.GetComponent<charMovement>().interacting)
            {
                interact = true;
                if (buttons.activeInHierarchy)
                {
                    buttons.SetActive(false);
                    buttonsOn = true;
                }
            }
            player.GetComponent<charMovement>().interacting = true;
            player.GetComponent<charMovement>().horizontal = 0f;
            menu.SetActive(true);
            open = true;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && open)
        {
            if (interact)
            {
                if (buttonsOn)
                    buttons.SetActive(true);
            }
            else
                player.GetComponent<charMovement>().interacting = false;
            foreach (GameObject page in activePgs)
            {
                page.SetActive(false);
            }
            activePgs.Clear();
            menu.SetActive(false);
            open = false;
            inventory.SetActive(false);
            instruc.SetActive(false);
        }
    }

    public void Resume()
    {
        if (interact)
        {
            if (buttonsOn)
                buttons.SetActive(true);
        }
        else
            player.GetComponent<charMovement>().interacting = false;
        menu.SetActive(false);
        open = false;
    }

    public void Pages()
    {
        menu.SetActive(false);
        inventory.SetActive(true);
        pgs = GameObject.FindGameObjectsWithTag("Pages");
        for (int i = 0; i < pgs.Length; i++)
        {
            if (pgs[i].GetComponent<PageViewer>().hasGotPage)
            {
                if (pgs[i].name == "page0")
                {
                    page0.SetActive(true);
                    activePgs.Add(page0);
                }

                else if (pgs[i].name == "page1")
                {
                    page1.SetActive(true);
                    activePgs.Add(page1);
                }

                else if (pgs[i].name == "page2")
                {
                    page2.SetActive(true);
                    activePgs.Add(page2);
                }

                else if (pgs[i].name == "page3")
                {
                    page3.SetActive(true);
                    activePgs.Add(page3);
                }

                else if (pgs[i].name == "page4")
                {
                    page4.SetActive(true);
                    activePgs.Add(page4);
                }

                else if (pgs[i].name == "page5")
                {
                    page5.SetActive(true);
                    activePgs.Add(page5);
                }

                else if (pgs[i].name == "page6")
                {
                    page6.SetActive(true);
                    activePgs.Add(page6);
                }

                else if (pgs[i].name == "page7")
                {
                    page7.SetActive(true);
                    activePgs.Add(page7);
                }
            }
        }
    }

    public void PagesBack()
    {
        foreach (GameObject page in activePgs)
        {
            page.SetActive(false);
        }
        activePgs.Clear();
        inventory.SetActive(false);
        menu.SetActive(true);
        instruc.SetActive(false);
    }

    public void Instructions()
    {
        menu.SetActive(false);
        instruc.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Instruc");
    }

    public void  Quit()
    {
        Application.Quit();
    }
}
