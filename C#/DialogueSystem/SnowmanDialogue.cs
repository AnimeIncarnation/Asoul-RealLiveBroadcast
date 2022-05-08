using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnowmanDialogue : MonoBehaviour
{
    //运行时不变
    [SerializeField]
    public GameObject panel;        //对话框
    public Text text;               //对话文本
    public int headImgIndex = 0;    //头顶提示的子物体序号
    public Image diaImg;            //对话头像
    public TextAsset textFile;      //文本文件——需要修改
    public Sprite XWimg;
    public Sprite NLimg;
    public Sprite XRimg;
    public GameObject box1;


    //运行时修改
    private bool isEnter = false;      
    private int textIndex = 0;
    private List<string> textList;
    private bool used = false;

    void Start()
    {
        textList = new List<string>();
        GetText(textFile);
    }

    void Update()
    {
        if (isEnter && !used)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                if (textIndex == textList.Count)
                {
                    panel.SetActive(false);
                    textIndex = 0;
                    transform.GetChild(headImgIndex).gameObject.SetActive(false);
                    isEnter = false;
                    used = true;
                    box1.SetActive(true);
                }

                int temp = int.Parse(textList[textIndex]);
                switch (temp)
                {
                    case 1:
                        diaImg.sprite = NLimg;
                        ++textIndex;
                        break;
                    case 2:
                        diaImg.sprite = XWimg;
                        ++textIndex;
                        break;
                    case 3:
                        diaImg.sprite = XRimg;
                        ++textIndex;
                        break;
                }
                
                if (isEnter)
                {
                    text.text = textList[textIndex];
                    panel.SetActive(true);
                    ++textIndex;
                }
            }
        }
    }


    void GetText(TextAsset textFile)
    {
        string[] tempList = textFile.text.Split('\n');
        foreach (string line in tempList)
        {
            textList.Add(line);
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Players" && !used)
        {
            print("碰撞");
            isEnter = true;
            transform.GetChild(headImgIndex).gameObject.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Players" && panel.activeSelf == false)
        {
            isEnter = false;
            transform.GetChild(headImgIndex).gameObject.SetActive(false);
        }
    }
}
