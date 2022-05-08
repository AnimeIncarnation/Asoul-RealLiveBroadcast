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
        if (col.name == "����")
        {
            if (!used)
            {
                EventCenter.Instance.InvokeEvent("ShowDialogue");
                if (CreateDialogue.instance.Create(XWfile))
                {
                    print("�ļ�����ɹ���");
                    used = true;
                }
            }
        }
        else if (col.name == "����")
        {
            if (!used)
            {
                EventCenter.Instance.InvokeEvent("ShowDialogue");
                if (CreateDialogue.instance.Create(NLfile))
                {
                    print("�ļ�����ɹ���");
                    used = true;
                }
            }
        }
    }
}
