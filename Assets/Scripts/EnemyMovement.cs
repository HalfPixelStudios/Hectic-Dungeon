using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public GameObject movePoint;
    [SerializeField] [Range(0.001f, 1f)] public float move_speed;
    bool facing = true; //1 - facing right, 0 facing left

    void Awake() {
        movePoint.transform.parent = null;
    }

    void Update() {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, movePoint.transform.position, move_speed);
    }
    public void move()
    {
        movePoint.transform.position += GetComponent<EnemyAI>().nextStep;
    }
    


}
