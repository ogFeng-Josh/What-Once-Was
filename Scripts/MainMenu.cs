using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button controlsButton;
    public Button quitButton;

    void Update()
    {
        startButton.onClick.AddListener(beginPlaying);
        controlsButton.onClick.AddListener(loadControls);
        quitButton.onClick.AddListener(quitGame);
    }

    void beginPlaying()
    {
        SceneManager.LoadScene("MasterScene");
    }
    void loadControls()
    {
        SceneManager.LoadScene("ControlsScene");
    }
    void quitGame()
    {
        Application.Quit();
    }

}
