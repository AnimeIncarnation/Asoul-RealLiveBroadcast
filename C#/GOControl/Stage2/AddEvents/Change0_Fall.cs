using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change0_Fall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.Instance.AddEvent("Change0",Fall);
    }

    void Fall()
    {
        GetComponent<Rigidbody2D>().isKinematic = false;
    }
}
