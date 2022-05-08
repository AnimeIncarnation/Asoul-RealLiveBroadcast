using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RayTest : MonoBehaviour
{
    public static bool XW = false;
    public static bool JL = false;
    public static bool NL = false;
    public static bool YES = false;
    public static int state = 0;


    public AudioClip clip;
    public AudioSource audio;
    


    public GameObject video;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //print(pos);
            //print(Input.mousePosition);
            RaycastHit2D hit = Physics2D.BoxCast(Input.mousePosition, new Vector2(1,1),0,Vector2.right);
            print(hit);
                if (hit.collider.gameObject.name == "向晚")
                {
                    print("按了向晚");
                    XW = !XW;
                audio.clip = clip;
                audio.PlayOneShot(clip);
            }
                else if (hit.collider.gameObject.name == "珈乐")
                {
                    print("按了珈乐");
                    JL = !JL;
                audio.clip = clip;
                audio.PlayOneShot(clip);
            }
                else if (hit.collider.gameObject.name == "乃琳")
                {
                    print("按了乃琳");
                    NL = !NL;
                audio.clip = clip;
                audio.PlayOneShot(clip);
            }
        }
        
        if ((XW && JL && !NL) || (XW && NL && !JL))
        {
            YES = true;
        }
        else
        {
            YES = false;
        }
    }

    void Start()
    {
        state = 0;
    }


    public void StartGame()
    {
        if (YES)
        {
            print("允许开始");
            if (XW && JL)
            {
                state = 2;
                audio.clip = clip;
                audio.PlayOneShot(clip);
                EventCenter.Instance.InvokeEvent("开始游戏");
            }
            else if (XW && NL)
            {
                state = 1;
                audio.clip = clip;
                audio.PlayOneShot(clip);
                EventCenter.Instance.InvokeEvent("开始游戏");
            }
        }
    }
}
