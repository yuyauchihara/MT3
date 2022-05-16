using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ude : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyUp("joystick button 5"))
        {
            gameObject.SetActive(false);
        }
        if (Input.GetKey("joystick button 5"))
        {
            gameObject.SetActive(true);
        }
        
    }
}
