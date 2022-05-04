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
        rb.velocity = new Vector2(move, 0);
    }

    IEnumerator Fry()
    {
        move = -8f;
        yield return new WaitForSeconds(3f);
        move = 0f;
        yield return new WaitForSeconds(5f);
    }

}
