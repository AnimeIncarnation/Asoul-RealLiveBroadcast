using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherTopographyDying : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        EventCenter.Instance.AddEvent("TopographyChange2", TopoChange2);
    }

    void TopoChange2()
    {
        gameObject.SetActive(false);
        print("触发TopographyChange2的TopoChange2事件");
    }
}
