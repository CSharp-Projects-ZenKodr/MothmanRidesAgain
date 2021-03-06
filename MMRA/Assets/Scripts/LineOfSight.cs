﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    RaycastHit2D hit;
    public EnemyAlert alert;
    // Start is called before the first frame update
    void Start()
    {
    }

   

    // Update is called once per frame
    void Update()
    {
      
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        hit = Physics2D.Raycast(transform.position, other.transform.position - transform.position);
        if (other.gameObject.tag == ("Player"))
        {
            if (hit.collider == other)
            {
                alert.detected = true;
                Debug.Log("Clear Line of Sight");
            }
            else
            {
                alert.detected = false;
                Debug.Log("Wall Intervening");
            }



        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == ("Player"))
        {
            alert.detected = false;
        }
    }
}
