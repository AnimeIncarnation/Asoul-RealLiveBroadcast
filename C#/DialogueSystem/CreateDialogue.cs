using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateDialogue : MonoBehaviour
{
    //外界需要做的事情：调用Create，并让本脚本挂载的对象Active
    public static CreateDialogue instance;

    public TextAsset fileDeath;

    private string[] txtBox;
    private int      iter = 0;
    private bool     enterDialogue = false;

    public Image diaImg;
    public Text  diaTxt;

    public void Invoke()
    {
        this.gameObject.SetActive(true);
    }

    void Awake()
    {
        instance = this;
        diaImg = transform.GetChild(1).gameObject.GetComponent<Image>();
        diaTxt = transform.GetChild(0).gameObject.GetComponent<Text>();
        EventCenter.Instance.AddEvent("ShowDialogue",Invoke);

        //如果第一次玩，关闭UI；如果是死过来的，开启UI
        if (TryTimes.tryTimes == 0)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            if (Create(fileDeath))
            {
                print("文件输入成功！");
            }
        }
        
    }

    void Update()
    {
        Output();
    }

    
    public bool Create(TextAsset txt)
    {
        if (!enterDialogue)
        {
            txtBox = null;
            InputTxt(txt);
            enterDialogue = true;
            int temp;
            if (int.TryParse(txtBox[iter],out temp))
            {
                diaImg.enabled = true;
                ImageJudge(int.Parse(txtBox[iter]));
            }
            else
            {
                diaImg.enabled = false;
            }
            TextChange();
            return true;
        }
        else { return false; }
    }

    private void InputTxt(TextAsset txt)
    {
        txtBox = txt.text.Split('\n');
        foreach (var x in txtBox) { print(x); }
    } 

    private void Output()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (iter == txtBox.Length)
            {
                iter = 0;
                this.gameObject.SetActive(false);
                enterDialogue = false;
                return;
            }
            int temp ;
            if (int.TryParse(txtBox[iter], out temp))
            {
                diaImg.enabled = true;
                ImageJudge(int.Parse(txtBox[iter]));
            }
            else
            {
                diaImg.enabled = false;
            }
            TextChange();
        }
    }

    private void ImageJudge(int x)
    {
        switch (x)
        {
            case 1:
                diaImg.sprite = Resources.Load<Sprite>(DialogueEnumSprite.NAILIN);
                ++iter;
                break;
            case 2:
                diaImg.sprite = Resources.Load<Sprite>(DialogueEnumSprite.XIANGWAN);
                ++iter;
                break;
            case 4:
                diaImg.sprite = Resources.Load<Sprite>(DialogueEnumSprite.YANGTUO);
                ++iter;
                break;
            case 5:
                diaImg.sprite = Resources.Load<Sprite>(DialogueEnumSprite.JIALE);
                ++iter;
                break;
            case 6:
                diaImg.sprite = Resources.Load<Sprite>(DialogueEnumSprite.YIGEHUN);
                ++iter;
                break;
            default: break;
        }
    }

    private void TextChange()
    {
        diaTxt.text = txtBox[iter];
        ++iter;
    }

}
