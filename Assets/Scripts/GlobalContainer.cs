using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalContainer : MonoBehaviour {

    public static GlobalContainer global;
    [SerializeField] public GameObject floor;
    public List<List<int>> tiles;
    public bool playerMoved;
    public GameObject enemies;
    

    private void Awake() {
        global = this;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (playerMoved)
        {
            foreach (var enemy in enemies.GetComponentsInChildren<EnemyMovement>())
            {
                enemy.move();
            }

            playerMoved = false;

        }
        
    }
}
