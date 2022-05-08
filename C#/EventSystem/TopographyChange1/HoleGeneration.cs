using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleGeneration : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        EventCenter.Instance.AddEvent("TopographyChange1", HoleGenerating);
    }

    void HoleGenerating()
    {
        gameObject.SetActive(false);
        print("触发TopographyChange1的HoleGeneration事件");
    }
}
