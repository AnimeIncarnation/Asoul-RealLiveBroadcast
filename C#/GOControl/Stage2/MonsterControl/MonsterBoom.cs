using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MonsterBoom :MonsterBase
{
    public Tilemap tile;
    public Tilemap tileBoss;

    public GameObject jc1;
    public GameObject jc2;
    public GameObject jc3;
    public GameObject jc4;
    public GameObject jc5;
    public GameObject jc6;
    public GameObject jc7;



    void Boom()
    {
        Vector3Int v3 = new Vector3Int((int)transform.position.x,(int)transform.position.y,(int)transform.position.z);
        for (int i = v3.x - 4; i < v3.x + 4; ++i)
        {
            for (int j = v3.y - 5; j < v3.y + 3; ++j)
            {
                //print(tile.WorldToCell(new Vector3Int(i, j, v3.z)));
                tile.SetTile(tile.WorldToCell(new Vector3Int(i,j,v3.z)), null);
                if(tileBoss != null)
                    tileBoss.SetTile(tile.WorldToCell(new Vector3Int(i, j, v3.z)), null);
            }
        }

        EventCenter.Instance.InvokeEvent("Boommm");
        if (gameObject.name == "Õ¨µ¯ÈË")
        {
            Jianci();
        }
        Destroy(gameObject);
    }

    void Jianci()
    {
        if (Mathf.Abs(jc1.transform.position.x - transform.position.x) < 4)
        {
            Destroy(jc1);
        }
        if (Mathf.Abs(jc2.transform.position.x - transform.position.x) < 4)
        {
            Destroy(jc2);
        }
        if (Mathf.Abs(jc3.transform.position.x - transform.position.x) < 4)
        {
            Destroy(jc3);
        }
        if (Mathf.Abs(jc4.transform.position.x - transform.position.x) < 4)
        {
            Destroy(jc4);
        }
        if (Mathf.Abs(jc5.transform.position.x - transform.position.x) < 4)
        {
            Destroy(jc5);
        }
        if (Mathf.Abs(jc6.transform.position.x - transform.position.x) < 4)
        {
            Destroy(jc6);
        }
        if (Mathf.Abs(jc7.transform.position.x - transform.position.x) < 4)
        {
            Destroy(jc7);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (life > 0)
        {
            if (col == swordColXW)
            {
                if (XiangWanControl2.instance.transform.position.x < transform.position.x)
                {
                    //rd.velocity += new Vector2(3, 0);
                    print("»÷ÍË");
                    rd.AddForce(new Vector2(force, 0));
                }
                else
                {
                    print("»÷ÍË");
                    rd.AddForce(new Vector2(-force, 0));
                }
                life -= 0.5f;
                XiangWanControl2.instance.swordLife -= 0.5f;
                StartCoroutine(Blink(gameObject));
            }
            else if (col == swordColJL)
            {
                if (JiaLeControl.instance.transform.position.x < transform.position.x)
                {
                    print("»÷ÍË");
                    rd.AddForce(new Vector2(force, 0));
                }
                else
                {
                    print("»÷ÍË");
                    rd.AddForce(new Vector2(-force, 0));
                }
                life -= 1;
                JiaLeControl.instance.swordLife -= 0.25f;
                StartCoroutine(Blink(this.gameObject));
            }
        }
    }
}
