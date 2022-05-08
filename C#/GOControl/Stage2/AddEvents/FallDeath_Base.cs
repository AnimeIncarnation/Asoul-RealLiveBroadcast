using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDeath_Base : MonoBehaviour
{
    //public TextAsset file;

    void Start()
    {
        EventCenter.Instance.AddEvent("FallDeath", Fall);
    }

    void Fall()
    {
        EventCenter.Instance.Clear();
        SceneManager.LoadScene("¹Ø¿¨2");
        TryTimes.tryTimes++;
    }
}
