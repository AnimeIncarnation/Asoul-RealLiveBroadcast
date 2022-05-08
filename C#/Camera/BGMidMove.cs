using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMidMove : MonoBehaviour
{
    public GameObject camera;
    private float camerax;
    private float myx;
    private float myx1;

    void Update()
    {
        camerax = camera.transform.position.x;
        transform.position = new Vector3(0.75f*camerax, transform.position.y, transform.position.z);
    }

}
