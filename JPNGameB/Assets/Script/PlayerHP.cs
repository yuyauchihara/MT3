﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    //public GameObject Ply;
    public Slider Tairyoku;
    float HealthPoint = 10.0f;
    float MaxHP = 10.0f;

    bool HoldShield = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q) || Input.GetKey("joystick button 5"))
        {
            HoldShield = true;
        }
        else
        {
            HoldShield = false;
        }

        Tairyoku.value = HealthPoint / MaxHP;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (HoldShield == false)
        {
            if (other.gameObject.tag == "bullet")
            {
                HealthPoint--;
                Destroy(other.gameObject);
            }
        }
        
    }
}
