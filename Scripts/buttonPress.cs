using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class buttonPress : MonoBehaviour
{
    public string inputString;
    public string buttonValue;

    public void ButtonPressed()
    {
        AudioSource click = gameObject.GetComponent<AudioSource>();
        click.Play();
        buttonValue = EventSystem.current.currentSelectedGameObject.name;
        if (buttonValue == "Enter")
        {
            return;
        }
        else
            inputString += buttonValue;
    }
}
