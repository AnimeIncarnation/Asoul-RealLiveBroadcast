using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceShow : MonoBehaviour
{
    public GameObject o1;
    public GameObject o2;
    public GameObject o3;
    

    void Update()
    {
        if (RayTest.XW)
        {
            o1.SetActive(true);

        }
        else
        {
            o1.SetActive(false);
        }

        if (RayTest.NL)
        {
            o2.SetActive(true);
        }
        else
        {
            o2.SetActive(false);
        }
        if (RayTest.JL)
        {
            o3.SetActive(true);
        }
        else
        {
            o3.SetActive(false);
        }

    }
}
