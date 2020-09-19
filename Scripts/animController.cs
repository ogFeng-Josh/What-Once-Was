using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animController : MonoBehaviour
{

    public Animator animator;
    public string animationOneName;
    public string animationTwoName;
    public string animationThreeName;
    public GameObject on;
    public GameObject off;

    private bool inBounds = false;
    private int lvl = 1;

    private void Start()
    {
        on.SetActive(true);
        off.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inBounds)
        {
            if (lvl == 1)
            {
                animator.Play(animationOneName);

                Debug.Log(animator.GetCurrentAnimatorStateInfo(0));

                if (animator.GetCurrentAnimatorStateInfo(0).IsName(animationOneName))
                {
                    Debug.Log("playing");
                }

                    lvl = 2;
            }

            else if (lvl == 2)
            {
                animator.Play(animationTwoName);
                lvl = 3;
            }

            else if (lvl == 3)
            {
                animator.Play(animationThreeName);
                lvl = 1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        inBounds = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inBounds = false;
    }

}
