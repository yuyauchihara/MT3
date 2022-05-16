using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMgr2_3 : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject MirrorBoss;
    public GameObject Point1, Point2, PointBoss;
    private bool isSpawned = false;
    public static bool isZenmetu = false;

    bool isMBSpawned = false;

    GameObject Zako1,Zako2,MirBos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DmgMgr.Dmg >= 1 && isMBSpawned == false)
        {
            MirBos = Instantiate(MirrorBoss, PointBoss.transform.position, Quaternion.identity);
            isMBSpawned = true;
        }

        if (Muzzle2_3.isBursted == true && isSpawned == false)
        {
            Zako1 = Instantiate(Enemy, Point1.transform.position, Quaternion.identity);
            Zako2 = Instantiate(Enemy, Point2.transform.position, Quaternion.identity);
            isSpawned = true;
        }

        if(Zako1.activeSelf == false && Zako2.activeSelf == false)
        {
            isZenmetu = true;
        }

        Debug.Log(DmgMgr.Dmg);

    }
}
