using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapTest : MonoBehaviour
{
    public Tilemap tile;

    void Start()
    {
        StartCoroutine(F());
    }

    IEnumerator F()
    {
        while (true)
        {
            print(tile.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
            yield return new WaitForSeconds(1);
        }
        
    }
}
