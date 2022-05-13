using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMgr2_3 : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Point1, Point2;
    private bool isSpawned = false;


    GameObject Zako1,Zako2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Muzzle2_3.isBursted == true && isSpawned == false)
        {
            Zako1 = Instantiate(Enemy, Point1.transform.position, Quaternion.identity);
            Zako2 = Instantiate(Enemy, Point2.transform.position, Quaternion.identity);
            isSpawned = true;
        }
    }
}
