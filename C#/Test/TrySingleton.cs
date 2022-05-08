using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrySingleton : MonoBehaviour
{
    void Awake()
    {
        EventCenter.Instance.AddEvent("游戏开始", ()=> { print("Delegate: 游戏开始捏");  } );
    }

    void Update()
    {
        EventCenter.Instance.InvokeEvent("游戏开始");
    }
}
