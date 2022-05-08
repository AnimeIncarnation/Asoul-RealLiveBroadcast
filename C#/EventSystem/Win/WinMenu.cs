using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        EventCenter.Instance.AddEvent("Win!", ShowMenu);
        EventCenter.Instance.AddEvent("Win!", StopTime);
        gameObject.SetActive(false);
    }


    void ShowMenu()
    {
        gameObject.SetActive(true);
    }

    void StopTime()
    {
        Time.timeScale = 0;
    }
}
