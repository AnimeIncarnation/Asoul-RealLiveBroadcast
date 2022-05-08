using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrySingleton : MonoBehaviour
{
    void Awake()
    {
        EventCenter.Instance.AddEvent("��Ϸ��ʼ", ()=> { print("Delegate: ��Ϸ��ʼ��");  } );
    }

    void Update()
    {
        EventCenter.Instance.InvokeEvent("��Ϸ��ʼ");
    }
}
