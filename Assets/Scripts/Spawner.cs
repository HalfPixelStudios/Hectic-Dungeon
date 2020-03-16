using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float spawnTimer;
    private float interval=3;
    public List<GameObject> enemyFabs;
    public List<GameObject> itemFabs;
    void Start()
    {
    }

    GameObject Spawn(List<GameObject> prefabs)
    {
        
        while (true)
        {
            int x = Random.Range(1, 11);
            int y = Random.Range(1, 11);
            if (GlobalContainer.global.tiles[y][x] == 1) 
            { 
                return Instantiate(prefabs[Random.Range(0, prefabs.Count - 1)],new Vector3(1.5f+x, -1.5f-y, 0),Quaternion.identity);
                
            }

        }
        
        

    }

    public void SpawnEnemy()
    {
        Spawn(enemyFabs).transform.parent = GlobalContainer.global.enemies.transform;
    }

    public void SpawnEquipment()
    {
        Spawn(itemFabs).transform.parent = GlobalContainer.global.items.transform;
    }
}
