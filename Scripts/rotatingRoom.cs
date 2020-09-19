
//With help from: https://answers.unity.com/questions/1202034/smooth-90-degree-rotation-on-keypress.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingRoom : MonoBehaviour
{
    public bool rotating = false;
    public GameObject red;
    public GameObject green;

    public IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        rotating = true;
        red.SetActive(true);
        green.SetActive(false);
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t <= 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
        transform.rotation = toAngle;
        red.SetActive(false);
        green.SetActive(true);
        rotating = false;
    }
}

