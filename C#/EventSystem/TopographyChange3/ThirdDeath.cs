using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdDeath : MonoBehaviour
{
    void Awake()
    {
        EventCenter.Instance.AddEvent("TopographyChange3", ThirdDying);
    }

    void ThirdDying()
    {
        gameObject.SetActive(false);
        print("触发TopographyChange3的ThirdDying事件");
        XiangWanControl.instance.gameObject.GetComponent<CharatorLife>().coldValue -= 50;
    }
}
