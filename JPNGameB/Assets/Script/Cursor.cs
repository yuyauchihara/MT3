using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cursor : MonoBehaviour
{
    int Pos = 1;
    public int nummenu;
    public float linewidth;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown("down") && Pos != nummenu)
        {
            Vector3 tmp = this.transform.position;
            this.transform.position = new Vector3(tmp.x, tmp.y - linewidth, tmp.z);
            Pos += 1;
        }
        else if (Input.GetKeyDown("up") && Pos != 1)
        {
            Vector3 tmp = this.transform.position;
            this.transform.position = new Vector3(tmp.x, tmp.y + linewidth, tmp.z);
            Pos -= 1;
        }
        else if (Input.GetKeyDown("space") && Pos != 1)
        {
            function();
        }
    }

    void function()
    {
        if (Pos == 1)
        {
            // 一番上の項目を選んだときの動作
            // 好きな動作を入れてね
        }
        else if (Pos == 2)
        {

        }
    }
}