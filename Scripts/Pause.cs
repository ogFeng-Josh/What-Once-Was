using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pause : MonoBehaviour
{
    public GameObject pauseScreen;
    public Button resumeButton;
    public Button quitButton;

    public bool resPressed;
    public bool quitPressed;
    // Start is called before the first frame update
    void Start()
    {
        pauseScreen = GameObject.FindGameObjectWithTag("Pause Screen");
        pauseScreen.SetActive(false);
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.visible = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
            quitButton.onClick.AddListener(QuitGame);
            resumeButton.onClick.AddListener(ResumeGame);
        }
    }
    void ResumeGame()
    {
        Cursor.visible = false;
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
    }
    void QuitGame()
    {
        Application.Quit();
    }
}
