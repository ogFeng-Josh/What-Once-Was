using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayCheck : MonoBehaviour
{
    public GameObject rayOne;
    public GameObject rayTwo;
    public GameObject rayThree;
    public GameObject redLight;
    public GameObject whiteLight;
    public bool interfere;
    public AudioClip AudioClip;

    private bool ht;

    // Update is called once per frame
    void Update()
    {
        Light_Enemy ray1 = rayOne.GetComponent<Light_Enemy>();
        Light_Enemy ray2 = rayTwo.GetComponent<Light_Enemy>();
        Light_Enemy ray3 = rayThree.GetComponent<Light_Enemy>();

        if (ray1.hitTarget || ray2.hitTarget || ray3.hitTarget)
            ht = true;
        else
            ht = false;

        if (ht && interfere != true)
        {
            AudioSource.PlayClipAtPoint(AudioClip, transform.position, .8f);
            StartCoroutine(Interference());
        }

    }

    IEnumerator Interference()
    {
        interfere = true;
        whiteLight.SetActive(false);
        redLight.SetActive(true);
        yield return new WaitForSeconds(10);
        interfere = false;
        ht = false;
        redLight.SetActive(false);
        whiteLight.SetActive(true);
    }
}
