using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public float time = 100;
    public Text text ;

    void Awake()
    {
        text = transform.GetChild(0).gameObject.GetComponent<Text>();
        EventCenter.Instance.AddEvent("BOSS战开始！",WakeUpUI);
        EventCenter.Instance.AddEvent("BossLose", BossLose);
        this.gameObject.SetActive(false);
    }
    
    void BossLose()
    {
        time = 100;
        gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        time -= Time.deltaTime;
        text.text = "剩余时间："+time.ToString("f0");
        if (time <= 0)
        {
            EventCenter.Instance.InvokeEvent("BossLose");
        }
    }

    void WakeUpUI()
    {
        this.gameObject.SetActive(true);
    }
}
