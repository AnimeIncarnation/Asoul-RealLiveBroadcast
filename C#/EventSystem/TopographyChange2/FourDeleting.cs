using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourDeleting : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        EventCenter.Instance.AddEvent("TopographyChange4", FourDelete);
    }

    void FourDelete()
    {
        gameObject.SetActive(false);
        print("触发TopographyChange4的FourDelete事件");
    }
}
