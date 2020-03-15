using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalContainer;


public class PlayerMovement : MonoBehaviour {

    PlayerInfo info;

    public GameObject movePoint;
    [Range(0f,1f)] public float moveThreshold;
    [Range(0.001f, 1f)] public float move_speed;
    bool facing = true; //1 - facing right, 0 facing left

    void Awake() {

        info = GetComponentInParent<PlayerInfo>();
        movePoint.transform.parent = null;
    }

    void Update() {
        //Move player by grid
        info.gameObject.transform.position = Vector2.MoveTowards(info.gameObject.transform.position, movePoint.transform.position, move_speed);
        
        //Get player input
        if (Vector2.Distance(info.gameObject.transform.position, movePoint.transform.position) <= moveThreshold) {
            Vector3 nextMove = Vector3.zero;

            if (Mathf.Abs(info.moveInput.x) >= info.inputThreshold) {
                facing = (info.moveInput.x >= 0) ? true : false;
                nextMove = new Vector3(info.moveInput.x / Mathf.Abs(info.moveInput.x), 0f, 0f);
            } else if (Mathf.Abs(info.moveInput.y) >= info.inputThreshold) {
                nextMove = new Vector3(0f, info.moveInput.y / Mathf.Abs(info.moveInput.y), 0f);
            }

            movePoint.transform.position += nextMove;
        }

    }
    
}
