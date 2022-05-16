using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryEnemy : MonoBehaviour
{
    Rigidbody2D rb;
    //public GameObject target;
    public GameObject muzzle;
    float move;
    private bool Seigen = false;
    private bool kaisuu = false;

    private int Time = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //StartCoroutine("Fry");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "FlySeigen")
        {
            Seigen = true;
            Time = 0;
            move = 0f;
            muzzle.SetActive(false);
            StageMgr.isBossAttack = true;
        }

        if(other.gameObject.tag == "FlySeigenR")
        {
            Seigen = false;
            Time = 0;
            move = 0f;
        }
    }

    void Update()
    {
        transform.Translate(move, 0, 0);
        //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, move);
    }

    void FixedUpdate()
    {
        if (Time > 120)
        {
            FlyEnemyMove();
        }
        
        if(Time <= 180)
        {
            Time++;
        }

        Debug.Log(Time);
    }

    void FlyEnemyMove()
    {
        if (!Seigen)
        {
            move = -0.08f;
        }
        else if (Seigen)
        {
            if (Time > 180)
            {
                muzzle.SetActive(true);
                move = 0.08f;
            }
            //else
            //{
            //    move = 0f;
            //    muzzle.SetActive(false);
            //    StageMgr.isBossAttack = true;
            //}
        }
    }

    //IEnumerator Fry()
    //{
    //    while(true)
    //    {
    //        yield return new WaitForSeconds(2.0f);
    //        move = -0.08f;
    //        yield return new WaitForSeconds(5.3f);
    //        move = 0f;
    //        muzzle.SetActive(false);
    //        StageMgr.isBossAttack = true;
    //        yield return new WaitForSeconds(4.5f);
    //        muzzle.SetActive(true);
    //        move = 0.08f;
    //        yield return new WaitForSeconds(4.3f);
    //    }
    //}
}
