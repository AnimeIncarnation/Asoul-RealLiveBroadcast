using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeDialogue_XW : MonoBehaviour
{
    public TextAsset file;
    private bool used = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "向晚")
        {
            if (!used)
            {
                EventCenter.Instance.InvokeEvent("ShowDialogue");
                if (CreateDialogue.instance.Create(file))
                {
                    print("文件输入成功！");
                    used = true;
                }
            }
        }
    }
}
