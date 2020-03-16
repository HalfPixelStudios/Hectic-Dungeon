using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float spawnTimer;
    private float interval=3;
    public List<GameObject> enemyFabs;
    void Start()
    {
    }
    
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > interval)
        {
            spawnTimer = 0;
            while (true)
            {
                int x = Random.Range(1, 11);
                int y = Random.Range(1, 11);
                if (GlobalContainer.global.tiles[y][x] == 1)
                {
                    Instantiate(enemyFabs[Random.Range(0, enemyFabs.Count - 1)],new Vector3(1.5f+x, -1.5f-y, 0),Quaternion.identity);
                }

            }
        }

    }
}
