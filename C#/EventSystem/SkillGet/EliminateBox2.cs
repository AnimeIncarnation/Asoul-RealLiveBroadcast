using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminateBox2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.Instance.AddEvent("XiangWanSkillGet", Eliminate);
    }

    void Eliminate()
    {
        gameObject.SetActive(false);
    }
}
