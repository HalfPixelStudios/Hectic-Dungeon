using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour {


    Dictionary<string, int[,]> patterndict = new Dictionary<string, int[,]>() {
        ["bomb"] = new int[5, 5] {
            { 0,0,0,0,0 },
            { 0,0,1,0,0 },
            { 0,1,1,1,0 },
            { 0,0,1,0,0 },
            { 0,0,0,0,0 },
        },
        ["axe"] = new int[3,3] {
            { 0,0,0 },
            { 1,1,1 },
            { 1,0,1 }
        },
        ["spear"] = new int[3,3] {
            { 0,1,0 },
            { 0,1,0 },
            { 0,1,0 }
        }
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
