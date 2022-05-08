using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHint : MonoBehaviour
{
    public TextAsset text;
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.Instance.AddEvent("TopographyChange1", Hint);
    }

    // Update is called once per frame
    void Hint()
    {
        GameObject x;
        x = GameObject.Instantiate(Resources.Load<GameObject>("Prefebs/GameObject"),new Vector3(47,0,0),transform.rotation);
        x.GetComponent<InvokeDialogue_1>().file = text;
    }
}
