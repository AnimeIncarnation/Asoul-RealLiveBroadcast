using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAnimation : MonoBehaviour
{
    private RectTransform rt;
    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rt.position += new Vector3(0,  rt.position.z,-rt.position.z);
        transform.position = rt.position;
    }
}
