using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private List<Sprite> tileSprites;
    

    // Start is called before the first frame update
    void Start()
    {

        var floor = GetComponent<GlobalContainer>().floor;
        for (int y = 0; y <14; y++)
        {
            for (int x = 0; x < 13; x++)
            {
                if (Random.Range(0f, 1f)<0.07f)
                {
                    continue;

                }
                

                GameObject g = Instantiate(tilePrefab, new Vector3(1.5f+x, -1.5f-y, 0), Quaternion.identity);
                g.AddComponent<SpriteRenderer>().sprite = tileSprites[Random.Range(0, 2)];
                g.transform.SetParent(floor.transform);
                
            }
            
        }
        
        
        
    }
}
