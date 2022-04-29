﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightObject : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col) {
       Debug.Log("hooray");
        if(col.gameObject.tag == "Player")
        { 
            
            player.gameObject.GetComponent<PlayerController>().SetLight(true);
        }
    }
    private void OnTriggerExit2D(Collider2D col) {
        if(col.gameObject.tag == "Player")
        {
            player.gameObject.GetComponent<PlayerController>().SetLight(false);
        }
    }
}
