using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvent1 : MonoBehaviour
{

    public AudioSource audio;
    
    public AudioClip box;
    public AudioClip earthquake;





    void Start()
    {
        EventCenter.Instance.AddEvent("NaiLinSkillGet", musicBox);
        EventCenter.Instance.AddEvent("XiangWanSkillGet", musicBox);
        EventCenter.Instance.AddEvent("TopographyChange1", musicEQ);
        EventCenter.Instance.AddEvent("TopographyChange2", musicEQ);
        EventCenter.Instance.AddEvent("TopographyChange3", musicEQ);
        EventCenter.Instance.AddEvent("TopographyChange4", musicEQ);
    }

    void musicBox()
    {
        audio.clip = box;
        audio.PlayOneShot(box);
    }

    void musicEQ()
    {
        audio.clip = earthquake;
        audio.PlayOneShot(earthquake);
    }

}
