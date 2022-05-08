using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FkWithBoss : MonoBehaviour
{
    public static bool entered = false;

    //处理文字对话
    public TextAsset file;
    private bool used = false;

    void Start()
    {
        EventCenter.Instance.AddEvent("BossLose",BossLose);
    }

    void BossLose()
    {
        used = false;
        entered = false;
        gameObject.GetComponent<CinemachineVirtualCamera>().Follow = GameObject.Find("向晚").transform;
        gameObject.GetComponent<Animator>().SetBool("enterBoss", false);
    }

    void FixedUpdate()
    {
        if (!entered)
        {
            //print("尝试");
            //print(NaiLinControl.instance.gameObject.transform);
            //print(XiangWanControl.instance.gameObject.transform);
            if (NaiLinControl.instance.gameObject.transform.position.x < -220 && XiangWanControl.instance.gameObject.transform.position.x < -220)
            {
                gameObject.GetComponent<CinemachineVirtualCamera>().Follow = GameObject.Find("Null_BossView").transform;
                gameObject.GetComponent<Animator>().SetBool("enterBoss", true);
                entered = true;
            }
        }
        if (entered)
        {
            if(!used)
            {
                EventCenter.Instance.InvokeEvent("ShowDialogue");
                if (CreateDialogue.instance.Create(file))
                {
                    print("文件输入成功！");
                    used = true;
                }
                EventCenter.Instance.InvokeEvent("BOSS战开始！");
            }
            
        }
    }
    
    
}
