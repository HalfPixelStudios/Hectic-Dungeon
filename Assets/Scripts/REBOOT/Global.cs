using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {

    [HideInInspector] public static Global global;
    public Grid grid;
    public GameObject player;
    public GameObject enemies;

    int playerMoves; //number of times the player has moved

    void Awake() {
        global = GetComponent<Global>();
    }

    public void playerWorldStep() { //game steps when player moves
        playerMoves += 1;

        foreach (Transform e in enemies.transform) { //all enemies move
            e.gameObject.GetComponent<EnemyController>().Move();
        }
    }

}
