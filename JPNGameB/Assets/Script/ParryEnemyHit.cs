using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryEnemyHit : MonoBehaviour
{
    public GameObject ParryHitEnemy;    //パリィの時の後ろの敵

    public static bool HitEnemy = false;      //パリィの時の後ろの敵を倒したかのフラグ

    void Update()
    {
        if(ParryHitEnemy == null)
        {
            HitEnemy = true;
            GetComponent<EnemyBody>().enabled = true;
        }
    }
}
