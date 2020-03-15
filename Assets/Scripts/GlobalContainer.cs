using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalContainer : MonoBehaviour {

    public static GlobalContainer global;
    [SerializeField] public GameObject floor;
    public List<List<int>> tiles;

    private void Awake() {
        global = this;
    }

}
