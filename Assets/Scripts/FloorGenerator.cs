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
        for (float y = -1.5f; y >-15; y--)
        {
            for (float x = 1.5f; x < 14.5f; x++)
            {

                GameObject g = Instantiate(tilePrefab, new Vector3(x, y, 0), Quaternion.identity);
                g.AddComponent<SpriteRenderer>().sprite = tileSprites[Random.Range(0, 2)];
                g.transform.SetParent(floor.transform);
            }
            
        }
        
        
        
    }
}
