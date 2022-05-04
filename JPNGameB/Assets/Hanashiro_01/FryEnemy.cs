using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryEnemy : MonoBehaviour
{
    Rigidbody2D rb;
    float move;
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
            move = -0.1f;
            yield return new WaitForSeconds(3.0f);
            move = 0.1f;
            yield return new WaitForSeconds(3.0f);
        }
    }

}
