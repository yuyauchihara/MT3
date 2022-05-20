using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryEnemyHit : MonoBehaviour
{
    public GameObject ParryHitEnemy;    //パリィの時の後ろの敵

    void Start()
    {
        GetComponent<EnemyBody>().enabled = false;
    }

    void Update()
    {
        if(ParryHitEnemy == null)
        {
            GetComponent<EnemyBody>().enabled = true;
        }
    }
}
