using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
public class Item : MonoBehaviour
{
    public GameObject inventoryHolder;

    public GameObject page0;
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public GameObject page4;
    public GameObject page5;
    public GameObject page6;
    public GameObject page7;

    public void Start()
    {
        inventoryHolder.SetActive(false);

        page0.SetActive(false);
        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(false);
        page4.SetActive(false);
        page5.SetActive(false);
        page6.SetActive(false);
        page7.SetActive(false);
    }

    public void Update()
    {
        if (page0.GetComponent<PageViewer>().hasGotPage)
        {
            page0.SetActive(true);
        }
        if (page1.GetComponent<PageViewer>().hasGotPage)
        {
            page1.SetActive(true);
        }
        if (page2.GetComponent<PageViewer>().hasGotPage)
        {
            page2.SetActive(true);
        }
        if (page3.GetComponent<PageViewer>().hasGotPage)
        {
            page3.SetActive(true);
        }
        if (page4.GetComponent<PageViewer>().hasGotPage)
        {
            page4.SetActive(true);
        }
        if (page5.GetComponent<PageViewer>().hasGotPage)
        {
            page5.SetActive(true);
        }
        if (page6.GetComponent<PageViewer>().hasGotPage)
        {
            page6.SetActive(true);
        }
        if (page7.GetComponent<PageViewer>().hasGotPage)
        {
            page7.SetActive(true);
        }
    }
}
