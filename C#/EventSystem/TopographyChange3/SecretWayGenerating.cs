using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretWayGenerating : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        EventCenter.Instance.AddEvent("TopographyChange3", SecretWay);
    }

    void SecretWay()
    {
        gameObject.SetActive(false);
        print("触发TopographyChange3的SecretWay事件");
    }
}
