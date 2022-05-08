using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminateBox1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.Instance.AddEvent("NaiLinSkillGet",Eliminate2);
        gameObject.SetActive(false);
    }

    void Eliminate2()
    {
        gameObject.SetActive(false);
    }
}
