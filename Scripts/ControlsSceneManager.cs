using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlsSceneManager : MonoBehaviour
{

    public Button returnToMain;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        returnToMain.onClick.AddListener(ReturnToMenu);
    }
    void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
