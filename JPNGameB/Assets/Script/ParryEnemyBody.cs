using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryEnemyBody : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet" && ParryEnemyHit.HitEnemy == true)
        {
            Destroy(gameObject);
        }
    }
}
