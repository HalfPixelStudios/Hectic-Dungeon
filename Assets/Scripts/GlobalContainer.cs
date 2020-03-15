using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalContainer : MonoBehaviour {

    public static GlobalContainer global;

    private void Awake() {
        global = this;
    }

}
