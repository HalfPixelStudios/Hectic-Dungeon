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

    Vector3 dir = Vector3.zero;
    void Awake() {

        info = GetComponentInParent<PlayerInfo>();
        movePoint.transform.parent = null;
    }

    void Update() {
        //Move player by grid
        
        info.gameObject.transform.position = Vector2.MoveTowards(info.gameObject.transform.position, movePoint.transform.position, move_speed);
        
        //Get player input
        if (Vector2.Distance(info.gameObject.transform.position, movePoint.transform.position) <= moveThreshold) {
            //assume keyboard
            int x = 0; int y = 0;
            if (Input.GetButtonDown("Up")) { y = 1; }
            else if (Input.GetButtonDown("Down")) { y = -1; }
            else if (Input.GetButtonDown("Left")) { x = -1; facing = false; }
            else if (Input.GetButtonDown("Right")) { x = 1; facing = true; }

            dir = new Vector3(x, y, 0);
            //Determine if move is valid

            Vector3 pos = info.interacter.GetComponent<BoxCollider2D>().transform.position;
            RaycastHit2D hit = Physics2D.Raycast(pos, dir, 1);

            if (hit && hit.collider.gameObject.GetComponent<InteractionHandler>() && hit.collider.gameObject.GetComponent<InteractionHandler>().isCollision) {
                info.interacter.GetComponent<PlayerInteracter>().TriggerInteract(hit.collider);
            } else {
                movePoint.transform.position += dir;
            }
            
            
            

            

            //flip playser sprite based on input
            info.sr.flipX = !facing;
        }

    }

    /*
    void OnDrawGizmos() {
        Gizmos.DrawLine(info.interacter.GetComponent<BoxCollider2D>().transform.position, info.interacter.GetComponent<BoxCollider2D>().transform.position + dir);
    }
    */
    

}
