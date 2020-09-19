using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scare : MonoBehaviour
{
    public GameObject imagery;
    public GameObject oldImagery;
    public GameObject active;
    public AudioClip noise;

    private bool triggered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggered == false && active.activeInHierarchy)
        {
            triggered = true;
            StartCoroutine(scareLoop());
        }
    }

    IEnumerator scareLoop()
    {
        if (oldImagery != null)
            oldImagery.SetActive(false);
        imagery.SetActive(true);
        AudioSource.PlayClipAtPoint(noise, transform.position);
        yield return new WaitForSeconds(10);
        if (oldImagery != null)
            oldImagery.SetActive(true);
        imagery.SetActive(false);
    }
}
