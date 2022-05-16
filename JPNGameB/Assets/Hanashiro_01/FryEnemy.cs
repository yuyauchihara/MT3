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
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("Fry");
    }

    void Update()
    {
        transform.Translate(move, 0, 0);
        //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, move);
    }

    IEnumerator Fry()
    {
        while(true)
        {
            if (!Seigen)
            {
                yield return new WaitForSeconds(2.0f);
                move = -0.08f;
                //yield return new WaitForSeconds(5.3f);
            }
            else if (Seigen)
            {
                move = 0f;
                muzzle.SetActive(false);
                StageMgr.isBossAttack = true;
                yield return new WaitForSeconds(4.5f);
                muzzle.SetActive(true);
                move = 0.08f;
                //yield return new WaitForSeconds(4.3f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "FlySeigen")
        {
            Seigen = true;
        }
    }
}
