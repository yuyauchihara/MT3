using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryEnemy : MonoBehaviour
{
    Rigidbody2D rb;
    float move;
    public GameObject muzzle;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("Fry");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(move, 0, 0);
    }

    IEnumerator Fry()
    {
        while(true)
        {
            yield return new WaitForSeconds(2.0f);
            move = -0.08f;
            yield return new WaitForSeconds(5.3f);
            move = 0f;
            muzzle.SetActive(false);
            StageMgr.isBossAttack = true;
            yield return new WaitForSeconds(4.5f);
            muzzle.SetActive(true);
            move = 0.08f;
            yield return new WaitForSeconds(5.3f);
        }
    }

}
