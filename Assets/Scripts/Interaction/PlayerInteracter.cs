using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D),typeof(Rigidbody2D))]
public class PlayerInteracter : MonoBehaviour {

    void Start() {
        
    }

    void Update() {
        
    }

    public void TriggerInteract(Collider2D collision) {
        if (collision.gameObject.GetComponent<InteractionHandler>() != null) {
            collision.gameObject.GetComponent<InteractionHandler>().OnInteraction();
        }

        if (collision.gameObject.GetComponent<EnemyMovement>() != null)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        TriggerInteract(collision);
    }
}
