using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventCenter 
{
    //����
    private static EventCenter instance = new EventCenter();
    public static EventCenter Instance
    {
        get{ return instance; }
    }

    //�¼��ֵ�-�޲��޷�
    private Dictionary<string, Action> actionDic = new Dictionary<string, Action>();

    //����¼�
    public bool AddEvent(string key, Action del)
    {
        try
        {
            if (actionDic.ContainsKey(key))
            {
                actionDic[key] += del ;
            }
            else
            {
                actionDic.Add(key, del);
            }
        }
        catch
        {
            Debug.Log($"EventCenter: Ϊ{key}����¼�����");
            return false;
        }
        Debug.Log($"EventCenter: Ϊ{key}����¼��ɹ�");
        return true;
    }


    //�����¼�
    public bool InvokeEvent(string key)
    {

        if (!actionDic.ContainsKey(key))
        {
            Debug.Log($"EventCenter: û������¼���{key}ʱ�޷�����");
            return false;
        }
        else
        {
            actionDic[key].Invoke();
            Debug.Log($"EventCenter: �ɹ�����{key}�¼�");
            
            return true;
        }

    }

    public bool Clear()
    {
        actionDic.Clear();
        return true;
    }

}
