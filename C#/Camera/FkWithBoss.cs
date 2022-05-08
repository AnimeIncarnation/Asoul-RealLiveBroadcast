using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FkWithBoss : MonoBehaviour
{
    public static bool entered = false;

    //�������ֶԻ�
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
        gameObject.GetComponent<CinemachineVirtualCamera>().Follow = GameObject.Find("����").transform;
        gameObject.GetComponent<Animator>().SetBool("enterBoss", false);
    }

    void FixedUpdate()
    {
        if (!entered)
        {
            //print("����");
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
                    print("�ļ�����ɹ���");
                    used = true;
                }
                EventCenter.Instance.InvokeEvent("BOSSս��ʼ��");
            }
            
        }
    }
    
    
}
