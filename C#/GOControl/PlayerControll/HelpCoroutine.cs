using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpCoroutine : MonoBehaviour
{
    public NaiLinControl NaiLin;
    public XiangWanControl XiangWan;


    void Start()
    {
        //Initialize
        NaiLin = NaiLinControl.instance;
        XiangWan = XiangWanControl.instance;
        StartCoroutine(HelpNaiLin());
        StartCoroutine(HelpXiangWan());
    }


    IEnumerator HelpNaiLin()
    {
        while (true)
        {
            if (NaiLin.rd.isKinematic && NaiLin.isJump)
            {
                NaiLin.isJump = false;
                NaiLin.W = false;
                NaiLin.anime.SetBool("IsJumping", false);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator HelpXiangWan()
    {
        while (true)
        {
            if (XiangWan.rd.isKinematic && XiangWan.isJump)
            {
                XiangWan.isJump = false;
                XiangWan.I = false;
                XiangWan.anime.SetBool("IsJumping", false);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
