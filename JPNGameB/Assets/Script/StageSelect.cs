using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    GameObject Object;
    SceneChange code;

    void Start()
    {
        Object = GameObject.Find("SceneChangeObject");
        code = Object.GetComponent<SceneChange>();
    }

    void Update()
    {
        if(Input.GetKey("joystick button 0"))
        {
            code.Scene = 0;
        }

        if(Input.GetKey("joystick button 1"))
        {
            code.Scene = 3;
        }

        if(Input.GetKey("joystick button 3"))
        {
            code.Scene = 6;
        }
    }
}
