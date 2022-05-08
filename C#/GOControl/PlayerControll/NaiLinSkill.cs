using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaiLinSkill : MonoBehaviour
{

    public GameObject hotPot;
    public int coolDownTime = 10;

    public AudioSource audio;
    public AudioClip clip;

    private bool isUsed = false;
    private float coolDownCal;
    private float axis;


    void Start()
    {
        coolDownCal = coolDownTime;
        EventCenter.Instance.AddEvent("NaiLinSkillGet", SkillGet);
        this.enabled = false;
    }

    
    void FixedUpdate()
    {
        CoolDown();
        SkillUsage();
    }

    void Update()
    {
        if (!isUsed)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                audio.PlayOneShot(clip);
                axis = transform.forward.x;
                print(axis);
                isUsed = true;
                GameObject.Instantiate(hotPot,new Vector3(transform.position.x+axis*1000,transform.position.y,transform.position.z),transform.rotation);
            }
        }
    }

    void SkillGet()
    {
        this.enabled = true;
    }


    void CoolDown()
    {
        if (isUsed)
        {
            coolDownCal -= Time.deltaTime;
            if (coolDownCal <= 0)
            {
                coolDownCal = coolDownTime;
                isUsed = false;
            }
        }
    }

    void SkillUsage()
    {
        if (isUsed)
        {

        }
    }


}
