using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventCenter 
{
    //单例
    private static EventCenter instance = new EventCenter();
    public static EventCenter Instance
    {
        get{ return instance; }
    }

    //事件字典-无参无返
    private Dictionary<string, Action> actionDic = new Dictionary<string, Action>();

    //添加事件
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
            Debug.Log($"EventCenter: 为{key}添加事件出错");
            return false;
        }
        Debug.Log($"EventCenter: 为{key}添加事件成功");
        return true;
    }


    //触发事件
    public bool InvokeEvent(string key)
    {

        if (!actionDic.ContainsKey(key))
        {
            Debug.Log($"EventCenter: 没有添加事件，{key}时无法触发");
            return false;
        }
        else
        {
            actionDic[key].Invoke();
            Debug.Log($"EventCenter: 成功触发{key}事件");
            
            return true;
        }

    }

    public bool Clear()
    {
        actionDic.Clear();
        return true;
    }

}
