using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : MonoBehaviour
{
    private GameObject equipped;

    void Start() {
        
        
    }
    
    void Update()
    {
        if (Input.GetButtonDown("UseItem")&&equipped!=null)
        {
            GetComponentInChildren<Equipment>().activate();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
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
