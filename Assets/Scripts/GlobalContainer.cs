using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalContainer : MonoBehaviour {

    public static GlobalContainer global;

    public PlayerInput input;

    private void Awake() {
        global = this;
        input = GetComponentInChildren<PlayerInput>();
    }

}
