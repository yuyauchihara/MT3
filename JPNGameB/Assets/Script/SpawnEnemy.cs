using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] Spawn;      //オブジェクトを格納する変数

    private int listSize = 0;       //格納する変数のサイズを取得する変数
    private int count;              //連続で呼ばれてヌルリファレンスを起こさないようにする処理

    public int delay = 0;           //敵の表示を遅延させる変数
    private float delayTime = 0;    //ディレイをかける時間

    private bool delayFlg = false;  //ディレイ処理をかける処理を入れるフラグ
    private bool SpawnFlg = false;  //敵が表示できるかのフラグ

    void Start()
    {
        count = 0;
        listSize = Spawn.Length;        //ここで変数のサイズを取得

        for (int i = 0; i < listSize; i++)
        {
            Spawn[i].gameObject.SetActive(false);    //敵を非表示する
        }
    }

    void FixedUpdate()
    {
        if (delayFlg)
        {
            delayTime++;
        }

        if(delayTime > delay)
        {
            SpawnFlg = true;
        }

        if (SpawnFlg && count == 0)
        {
            SpawnDelayEnemy();
            count = 1;
        }
    }

    void OnTriggerEnter2D(Collider2D other)     //敵が出てくるための処理
    {
        if (other.gameObject.tag == "Player" && count == 0)
        {
            delayTime = 0;
            delayFlg = true;
        }
    }

    private void SpawnDelayEnemy()
    {
        for (int i = 0; i < listSize; i++)
        {
            Spawn[i].gameObject.SetActive(true);    //敵を表示する
        }
        delayFlg = false;
    }
}
