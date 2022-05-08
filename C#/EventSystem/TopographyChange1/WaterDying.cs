using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDying : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        EventCenter.Instance.AddEvent("TopographyChange1", Water1Dying);
    }

    void Water1Dying()
    {
        gameObject.SetActive(false);
        print("����TopographyChange1��Water1Dying�¼�");
    }
}
