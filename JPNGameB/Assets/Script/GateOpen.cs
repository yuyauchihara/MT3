using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpen : MonoBehaviour
{
    public GameObject OpenGate;         //ゲートを格納する変数
    public GameObject[] GateEnemy;      //倒す敵を格納する変数

    private int EnemylistSize = 0;      //敵を格納する変数のサイズを取得する変数


    void Start()
    {
        EnemylistSize = GateEnemy.Length;       //ここで敵を格納する変数を取得

        OpenGate.gameObject.SetActive(true);    //ゲートを表示する
    }

    void OnTriggerEnter2D(Collider2D other)             //ここで敵が倒れているかを判断する
    {
        if (other.gameObject.tag == "Player")           //プレイヤーのタグに当たったら判断開始
        {
            for (int j = 0; j < EnemylistSize; j++)     //サイズ分の変数の中身を見る※今は複数には対応してない
            {
                if (GateEnemy[j] == null)               //中身が何もなかったら(デリートされてたら)※複数
                {
                    GateDelete();                       //ゲートを消すスクリプト開始
                }
            }
        }
    }

    void GateDelete()
    {
        OpenGate.gameObject.SetActive(false);           //ゲートを非表示にする
    }
}