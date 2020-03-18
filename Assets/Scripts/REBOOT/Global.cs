using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {

    [HideInInspector] public static Global global;
    public Grid grid;


    void Awake() {
        global = GetComponent<Global>();
    }

}
