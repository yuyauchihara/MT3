using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMgr2_3 : MonoBehaviour
{
    public GameObject Enemy; //雑魚
    public GameObject Boss; //ボス
    public GameObject MirrorBoss; //ミラーボス
    public GameObject Mirror; //鏡
    public GameObject Point1, Point2, PointMirror, PointBoss;
    public static bool isSpawned = false; //スポン検知
    public static bool isZenmetu = false;

    public static bool isResetBurst = false; //バーストカウントが無限に初期化される問題対策

    bool isMBSpawned = false;

    GameObject Zako1,Zako2,MirBos,Mir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DmgMgr.Dmg >= 15 && isMBSpawned == false) //ミラーフェーズ
        {
            MirBos = Instantiate(MirrorBoss, PointBoss.transform.position, Quaternion.identity);
            isMBSpawned = true;

            Mir = Instantiate(Mirror, PointMirror.transform.position, Quaternion.identity);
            Boss.SetActive(false);
        }

        if (Muzzle2_3.isBursted == true && isSpawned == false && Boss.activeSelf == true) //4回バーストしたら雑魚を出す
        {
            Zako1 = Instantiate(Enemy, Point1.transform.position, Quaternion.identity);
            Zako2 = Instantiate(Enemy, Point2.transform.position, Quaternion.identity);
            isSpawned = true; //無限スポーン対策            
        }

        if(Zako1.activeSelf == false && Zako2.activeSelf == false/* && isResetBurst == false*/)
        {
            isZenmetu = true; //全滅を検知
            Muzzle2_3.BurstCount = 0;
            isSpawned = false;

            //isResetBurst = true;
        }

        Debug.Log(DmgMgr.Dmg);

    }
}
