using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endLevel : MonoBehaviour
{
    public GameObject fadeOut;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fade());
        }
    }

    IEnumerator Fade()
    {
        fadeOut.GetComponent<Animator>().Play("FadeOut2");
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Credits");
    }
}
