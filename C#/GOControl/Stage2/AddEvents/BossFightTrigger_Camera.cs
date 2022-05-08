using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BossFightTrigger_Camera : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.Instance.AddEvent("BossFightTrigger",Change);
    }
    void Change()
    {
        anim.SetTrigger("BossFightTrigger");
    }
}
