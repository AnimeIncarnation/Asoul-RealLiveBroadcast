using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraCenterChange1 : MonoBehaviour
{
    private CinemachineVirtualCamera c;

    void Start()
    {
        c = this.GetComponent<CinemachineVirtualCamera>();
    }
    // Update is called once per frame
    void Update()
    {
        if(!FkWithBoss.entered)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(c.Follow == NaiLinControl.instance.gameObject.transform)
            {
                c.Follow = XiangWanControl.instance.gameObject.transform;
            }
            else if (c.Follow == XiangWanControl.instance.gameObject.transform)
            {
                c.Follow = NaiLinControl.instance.gameObject.transform;
            }
        }
    }
}
