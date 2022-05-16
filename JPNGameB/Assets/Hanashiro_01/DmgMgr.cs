using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgMgr : MonoBehaviour
{
    // Start is called before the first frame update
    public static int Dmg = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            Dmg++;
        }

        if (other.gameObject.tag == "HightPower")
        {
            Dmg += 2;
        }
    }

}
