using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightTrigger_Blood : MonoBehaviour
{
    void Start()
    {
        EventCenter.Instance.AddEvent("BossFightTrigger", Blood);
        gameObject.SetActive(false);
    }
    void Blood()
    {
        gameObject.SetActive(true);
    }
}
