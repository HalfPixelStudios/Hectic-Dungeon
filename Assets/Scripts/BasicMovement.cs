using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {

    static float moveThreshold = 0.05f;
    public GameObject movePoint;
    [Range(0.001f, 1f)] public float move_speed;
    
    void Start() {
        movePoint.transform.parent = null;
    }

    void Update() {

        transform.position = Vector2.MoveTowards(transform.position, movePoint.transform.position, move_speed);
        if (Vector2.Distance(transform.position, movePoint.transform.position) <= moveThreshold) {
            movePoint.transform.position += nextMove();
        }
    }

    public virtual Vector3 nextMove() {
        return Vector3.zero;
    }
}
