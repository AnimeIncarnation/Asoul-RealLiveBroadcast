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
        print("����TopographyChange3��ThirdDying�¼�");
        XiangWanControl.instance.gameObject.GetComponent<CharatorLife>().coldValue -= 50;
    }
}
