using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {

    [HideInInspector] public Global global;
    public Grid grid;


    void Start() {
        global = this.GetComponent<Global>();
    }

}
