using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioFix : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("One shot audio") != null)
        {
            GameObject audioSource = GameObject.Find("One shot audio");
            audioSource.GetComponent<AudioSource>().spatialBlend = 0;
        }
    }
}
