using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraCenterChange : MonoBehaviour
{
    private CinemachineVirtualCamera c;

    void Start()
    {
        c = this.GetComponent<CinemachineVirtualCamera>();
        FkWithBoss.entered = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(!FkWithBoss.entered)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(c.Follow == XiangWanControl2.instance.gameObject.transform)
            {
                c.Follow = JiaLeControl.instance.gameObject.transform;
            }
            else if (c.Follow == JiaLeControl.instance.gameObject.transform)
            {
                c.Follow = XiangWanControl2.instance.gameObject.transform;
            }
        }
    }
}
