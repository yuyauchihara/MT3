using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneFLG : MonoBehaviour
{
    public static bool ClearFlag = false;      //クリアするためのフラグ

    public SceneChange GetChange;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)             //ここで敵が倒れているかを判断する
    {
        if (other.gameObject.tag == "Player")          //プレイヤーのタグに当たったら判断開始
        {
            ClearFlag = true;                          //trueだとクリアできる
            GetChange.goalKenti();
        }
    }
}
