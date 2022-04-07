using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    public int EnemySousu = 0;

    public static int DeleteEnemy = 0;
    public static bool BattleEnemyDelete = false;

    void Update()
    {
        if(CameraChange.Battle == false)
        {
            DeleteEnemy = 0;
        }
    }
    private void CheckStart()
    {
        CameraChange.Battle = false;
        BattleEnemyDelete = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && DeleteEnemy == EnemySousu && BattleEnemyDelete)
        {
            CheckStart();
        }

        if (other.tag == "Player" && DeleteEnemy == EnemySousu && BattleEnemyDelete)
        {
            CheckStart();
        }
    }
}
