using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuyukan : MonoBehaviour
{
    Rigidbody2D rb;
    float move;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("Fuyu");
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, move);
    }

    IEnumerator Fuyu()
    {
        while (true)
        {
            move = 0.5f;
            yield return new WaitForSeconds(0.8f);
            move = -0.5f;
            yield return new WaitForSeconds(0.8f);
        }
    }
}
