using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NormalLose : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip clip;
  
    void Start()
    {
        EventCenter.Instance.AddEvent("Lose", Lose);
    }

    public void Lose()
    {
        audio.PlayOneShot(clip);
        EventCenter.Instance.Clear();
        TryTimes.tryTimes++;
        SceneManager.LoadScene("SampleScene");
    }
}
