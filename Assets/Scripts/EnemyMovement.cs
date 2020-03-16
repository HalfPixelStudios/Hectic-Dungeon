using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] [Range(0.001f, 1f)] public float move_speed;
    bool facing = true; //1 - facing right, 0 facing left
    public Vector3 movePoint;

    void Awake()
    {
        movePoint = transform.position;
    }

    void Update() {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, movePoint, move_speed);
    }
    public void move()
    {
        movePoint += GetComponent<EnemyAI>().nextStep;
    }
    


}
