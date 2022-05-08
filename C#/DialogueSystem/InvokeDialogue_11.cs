using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeDialogue_11 : MonoBehaviour
{
    public TextAsset XWfile;
    public TextAsset NLfile;
    private bool used = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "向晚")
        {
            if (!used)
            {
                EventCenter.Instance.InvokeEvent("ShowDialogue");
                if (CreateDialogue.instance.Create(XWfile))
                {
                    print("文件输入成功！");
                    used = true;
                }
            }
        }
        else if (col.name == "乃琳")
        {
            if (!used)
            {
                EventCenter.Instance.InvokeEvent("ShowDialogue");
                if (CreateDialogue.instance.Create(NLfile))
                {
                    print("文件输入成功！");
                    used = true;
                }
            }
        }
    }
}
