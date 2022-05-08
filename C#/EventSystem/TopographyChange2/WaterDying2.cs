using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDying2 : MonoBehaviour
{
    void Awake()
    {
        EventCenter.Instance.AddEvent("TopographyChange2", Water2Dying);
    }

    void Water2Dying()
    {
        gameObject.SetActive(false);
        print("触发TopographyChange2的Water2Dying事件");
    }
}
