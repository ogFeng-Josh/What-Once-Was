using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour
{
    public GameObject fadeOut;
    public AudioClip press;

    private bool end;
    private bool start;

    public void Begin()
    {
        start = true;
        AudioSource.PlayClipAtPoint(press, transform.position);
        StartCoroutine(fade());
    }

    public void Quit()
    {
        end = true;
        AudioSource.PlayClipAtPoint(press, transform.position);
        StartCoroutine(fade());
    }

    IEnumerator fade()
    {
        if (start)
        {
            fadeOut.GetComponent<Animator>().Play("FadeOut");
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("Instruc");
        }

        else if (end)
        {
            fadeOut.GetComponent<Animator>().Play("FadeOut");
            yield return new WaitForSeconds(2);
            Application.Quit();
        }
    }
}
