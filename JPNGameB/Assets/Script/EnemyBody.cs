using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBody : MonoBehaviour
{
    public int Life;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Life <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.tag == "bullet")
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            if (bullet.FriendlyFireFlag == true)
            {
                //gameObject.SetActive(false);
                Life--;
                Destroy(other.gameObject);
                if (CameraChange.Battle == true)
                {
                    Check.DeleteEnemy += 1;
                }
                Check.BattleEnemyDelete = true;
                bullet.FriendlyFireFlag = false;
            }
        }
    }
}