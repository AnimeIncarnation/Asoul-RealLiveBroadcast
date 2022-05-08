using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DealWithBoss : MonoBehaviour
{
    public static bool entered = false;

    //�������ֶԻ�
    public TextAsset file;
    private bool used = false;


    void FixedUpdate()
    {
        if (!entered)
        {
            if (NaiLinControl.instance.gameObject.transform.position.x < -220 && XiangWanControl.instance.gameObject.transform.position.x < -220)
            {
                gameObject.GetComponent<CinemachineVirtualCamera>().Follow = GameObject.Find("BossView").transform;
                gameObject.GetComponent<Animator>().SetBool("enterBoss", true);
                entered = true;
            }
        }
        if (entered)
        {
            if (!used)
            {
                EventCenter.Instance.InvokeEvent("ShowDialogue");
                if (CreateDialogue.instance.Create(file))
                {
                    print("�ļ�����ɹ���");
                    used = true;
                }
            }
        }
    }
    
    
}
