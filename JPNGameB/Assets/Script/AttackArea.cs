using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject EnemyCore;
    Transform pos,EnemyCorePos;
    New_AproachEnemy NAP;
    public static bool isInAttackArea = false;

    void Start()
    {
        pos = gameObject.GetComponent<Transform>();
        EnemyCorePos = EnemyCore.GetComponent<Transform>();
        NAP = EnemyCore.GetComponent<New_AproachEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        pos.position = EnemyCorePos.position; //AttackAreaのオブジェクトをEnemyCoreに追従させる処理
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "PlayerArea" && New_AproachEnemy.isAttack == false) //AttackAreaにプレイヤーが進入すると接近速度が上がる
        {
            NAP.EnemyMove = New_AproachEnemy.Direction * 5.5f;
            isInAttackArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerArea") //AttackAreaからプレイヤーが出ると接近速度が元に戻る
        {
            //NAP.EnemyMove = NAP.MoveSpeedAndDirection;
            isInAttackArea = false;
        }
    }

}
