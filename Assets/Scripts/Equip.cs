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
        if (Input.GetButtonDown("UseItem")) { 
            if (!info.isAiming) { //enter aiming mode
                info.isAiming = true;

            } else {
                info.isAiming = false;
                DestroyHighlights();
            }
        }

        //Update highlights
        if (info.isAiming) { //MAKE THIS BETTER AND NOT UPDATE EVERY LOOP

            //If item uses tile highlighting
            DestroyHighlights();


            int[,] inp = new int[3, 3] {
                {0,1,0},
                {0,1,0},
                {0,1,0}
            };
            Vector3 pos = info.interacter.GetComponent<BoxCollider2D>().transform.position;
            Debug.Log(info.facing);
            highlight = DrawHighlights.createPattern(Resources.Load("tile_select2") as GameObject, inp, pos, info.facing);
            
        }

        /*
        if (Input.GetButtonDown("UseItem")&&equipped!=null)
        {
            GetComponentInChildren<Equipment>().activate();
        }
        */

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
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponentInChildren<Equipment>() != null)
        {
            if (equipped != null)
            {
                Destroy(equipped);
            }
            Transform equipment = other.gameObject.transform.GetChild(0);
            equipment.SetParent(transform);
            equipped = equipment.gameObject;
            Destroy(other.gameObject);

        }
    }
}
