using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventDia : MonoBehaviour
{
    void Start()
    {
        print(TryTimes.tryTimes);
        if (TryTimes.tryTimes != 0)
        {
            gameObject.SetActive(false);
        }
    }
}
