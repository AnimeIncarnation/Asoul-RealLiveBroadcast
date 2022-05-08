using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Return1 : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip clip;
    
    public void Return()
    {
        audio.PlayOneShot(clip);
        EventCenter.Instance.Clear();
        TryTimes.tryTimes = 0;
        SceneManager.LoadScene("标题界面");
        
    }
}
