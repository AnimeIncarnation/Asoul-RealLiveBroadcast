using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderGeneration : MonoBehaviour
{
    void Awake()
    {
        EventCenter.Instance.AddEvent("TopographyChange1", LadderGenerating);
        gameObject.SetActive(false);
    }

    void LadderGenerating()
    {
        gameObject.SetActive(true);
        print("触发TopographyChange1的LadderGenerating事件");
    }
}
