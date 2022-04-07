﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBody : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.tag == "bullet")
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            gameObject.SetActive(false);
            if (CameraChange.Battle == true)
            {
                Check.DeleteEnemy += 1;
            }
            Check.BattleEnemyDelete = true;
        }
    }
}