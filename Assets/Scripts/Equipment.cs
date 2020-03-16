using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D),typeof(Rigidbody2D))]
public class Equipment : MonoBehaviour {


    Dictionary<string, int[,]> patterndict = new Dictionary<string, int[,]>() {
        ["bomb"] = new int[5, 5] {
            { 0,0,0,0,0 },
            { 0,0,1,0,0 },
            { 0,1,1,1,0 },
            { 0,0,1,0,0 },
            { 0,0,0,0,0 },
        },
        ["hammer"] = new int[3,3] {
            { 0,0,0 },
            { 1,1,1 },
            { 1,1,1 }
        },
        ["spear"] = new int[3,3] {
            { 0,1,0 },
            { 0,1,0 },
            { 0,1,0 }
        },
        ["dagger"] = new int[1,1] {
            { 1 }
        },
        ["sword"] = new int[3,3] {
            { 0,0,0 },
            { 0,1,0 },
            { 1,0,1 }
        },
        ["doom"] = new int[5, 5] {
            { 1,0,1,0,1 },
            { 1,0,1,0,1 },
            { 1,1,1,1,1 },
            { 0,1,1,1,0 },
            { 0,0,1,0,0 },
        },
    };

    public string name;
    [HideInInspector] public int[,] pattern;
    public int durability;

    void Start() {
        pattern = patterndict[name];
    }

    void Update() {
        
    }

    public virtual bool activate() { //returns false if the equipment broke
        durability -= 1;

        //deal damamge to all enemies that fall within the attack pattern

        if (durability <= 0) { return false; }

        return true;
    }
    
    
}
