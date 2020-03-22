using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Global;

public class EnemyController : MonoBehaviour {

    //user defined vars
    [Range(0f, 1f)] public float move_speed;

    //position on grid
    protected Vector2 pos;
    protected Vector2 facing = Vector2.up;

    void Start() {
        pos = new Vector2(4, 4);
    }

    void Update() {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, global.grid.GridToWorld((int)pos.x, (int)pos.y), move_speed);
    }

    public virtual void Move() { }
}
