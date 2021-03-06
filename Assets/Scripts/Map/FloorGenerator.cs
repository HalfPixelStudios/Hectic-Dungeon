﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private List<Sprite> tileSprites;
    [SerializeField] private List<GameObject> enviroObjs;
    
    

    // Start is called before the first frame update
    void Start()
    {
        var tiles=new List<List<int>>();

        var floor = GetComponent<GlobalContainer>().floor;
        for (int y = 1; y <12; y++)
        {
            var row = new List<int>();
            row.Add(0);
            for (int x = 1; x < 12; x++)
            {
                Vector3 pos = new Vector3(x + 1.5f, -1.5f - y, 0);
                if (!(GlobalContainer.global.player.transform.position == pos||GlobalContainer.global.ItemOrEnemyContains(pos)))
                {
                    if (Random.Range(0f, 1f)<0.04f)
                    {
                        row.Add(0);
                    
                    
                        continue;
                    }
                    
                }
                
                
                
                row.Add(1);
                GameObject g = Instantiate(tilePrefab, pos, Quaternion.identity);
                g.AddComponent<SpriteRenderer>().sprite = tileSprites[Random.Range(0, 2)];
                g.transform.SetParent(floor.transform);
                
            }
            tiles.Add(row);
            
        }
        tiles.Add(Enumerable.Repeat(0,14).ToList());
        tiles.Add(Enumerable.Repeat(0,14).ToList());

        GetComponent<GlobalContainer>().tiles = tiles;



    }

    
}
