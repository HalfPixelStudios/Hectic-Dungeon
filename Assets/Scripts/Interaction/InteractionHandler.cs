using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D),typeof(Rigidbody2D))]
public class InteractionHandler : MonoBehaviour {

    public bool isCollision;

    public virtual void OnInteraction() {

    }
}
