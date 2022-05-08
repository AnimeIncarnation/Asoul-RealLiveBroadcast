using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallDying : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        EventCenter.Instance.AddEvent("TopographyChange2", SnowBall);
    }

    void SnowBall()
    {
        gameObject.SetActive(false);
        print("����TopographyChange2��SnowBall�¼�");
    }
}
