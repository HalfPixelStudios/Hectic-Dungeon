using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : MonoBehaviour
{
    private GameObject equipped;
    PlayerInfo info;
    GameObject highlight;

    void Start() {
        info = GetComponentInParent<PlayerInfo>();
        
    }
    
    void Update() {
        if (Input.GetButtonDown("UseItem") && equipped != null) { 
            if (!info.isAiming) { //enter aiming mode
                info.isAiming = true;

            } else { //confirm item use 
                info.isAiming = false;
                DestroyHighlights();

                if(!equipped.GetComponent<Equipment>().activate()) { //use item
                    unequipEquipment(); //if its durability is used up, destroy it
                }

            }
        }

        //Update highlights
        if (info.isAiming) { //MAKE THIS BETTER AND NOT UPDATE EVERY LOOP

            //If item uses tile highlighting
            int[,] pattern = equipped.GetComponent<Equipment>().pattern;
            if (pattern != null) {
                DestroyHighlights();
                Vector3 pos = info.interacter.GetComponent<BoxCollider2D>().transform.position;
                highlight = DrawHighlights.createPattern(Resources.Load("tile_select2") as GameObject, pattern, pos, info.facing);
            }
            

            /*
            int[,] inp = new int[3, 3] {
                {0,1,0},
                {0,1,0},
                {0,1,0}
            };
            */


            
        }

    }
    private void DestroyHighlights() {
        if (highlight != null) { //remove previous highlight if it exists
            foreach (Transform t in highlight.transform) {
                Destroy(t.gameObject);
            }
            Destroy(highlight);
            highlight = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) { //EQUIP OBJECT
        if (other.gameObject.GetComponentInChildren<Equipment>() != null) {
            if (equipped != null) { Destroy(equipped); }//remove previous item if there is 

            Transform equipment = other.gameObject.transform.GetChild(0);

            equipment.SetParent(transform);
            equipment.localPosition = Vector3.zero;
            equipment.gameObject.active = false;
            equipped = equipment.gameObject;
            Destroy(other.gameObject);

        }
    }

    private void unequipEquipment() {
        if (equipped == null) { return; }

        Destroy(equipped);
        equipped = null;
    }
}
