using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharatorCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("����Trigger�ж�");
        if (other.gameObject.tag == "Food")
        {
            print("����TriggerFood�ж�");
            //other.gameObject.SetActive(false);
            if (other.gameObject.name == "1")
            {
                EventCenter.Instance.InvokeEvent("TopographyChange1");
            }
            else if(other.gameObject.name == "2")
            {
                EventCenter.Instance.InvokeEvent("TopographyChange2");
            }
            else if (other.gameObject.name == "3")
            {
                EventCenter.Instance.InvokeEvent("TopographyChange3");
            }
            else if (other.gameObject.name == "4")
            {
                EventCenter.Instance.InvokeEvent("TopographyChange4");
            }
            else if (other.gameObject.name == "Box1")
            {
                if(gameObject.name =="����")
                    EventCenter.Instance.InvokeEvent("NaiLinSkillGet");
            }
            else if (other.gameObject.name == "Box2")
            {
                if (gameObject.name == "����")
                    EventCenter.Instance.InvokeEvent("XiangWanSkillGet");
            }
        }
    }
}
