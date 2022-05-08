using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightTrigger_Foods : MonoBehaviour
{
    void Start()
    {
        EventCenter.Instance.AddEvent("Stage2", Foods);
        gameObject.SetActive(false);
    }
    void Foods()
    {
        gameObject.SetActive(true);
    }
}
