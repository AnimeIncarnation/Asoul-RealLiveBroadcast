using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change1_Boom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.Instance.AddEvent("Change1", Boom);
    }

    void Boom()
    {
        gameObject.GetComponent<MonsterBoom>().anim.SetTrigger("IsDead");
    }
}
