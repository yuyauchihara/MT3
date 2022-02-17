using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    Rigidbody2D rb;
    Rigidbody2D Refrb;
    float moveSpeed = 10.5f;
    public Material blue;
    public Material green;
    bool Guard = false;
    bool RefGuard = false;
    public bool KnockFlag = false;

    Vector2 Ref = new Vector2(5500, 0);
    Vector2 Knc = new Vector2(300, 0);
    // Start is called before the first frame update
    void Start()
    {        
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, 0);

        Vector2 force = new Vector2(0, 9000.0f);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
        {
            rb.AddForce(force);
        }

        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown("joystick button 1"))
        {
            //Reflection();
            //GetComponent<Renderer>().material.color = blue.color;
            //Guard = true;
            StartCoroutine("Reflection");
        }
        //else
        //{
        //    //GetComponent<Renderer>().material.color = green.color;
        //    Guard = false;
        //}
    }

    IEnumerator Reflection()
    {
        GetComponent<Renderer>().material.color = blue.color;
        RefGuard = true;
        yield return new WaitForSeconds(2);
        GetComponent<Renderer>().material.color = green.color;
        RefGuard = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            //Destroy(other.gameObject);
        }

        if (Guard == false)
        {
            if (other.gameObject.tag == "bullet")
            {
                //Destroy(gameObject);
                Destroy(other.gameObject);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            if(RefGuard == true)
            {
                Rigidbody2D Refrb = other.gameObject.GetComponent<Rigidbody2D>();
                Refrb.AddForce(Ref);
            }
        }
        
        if(other.gameObject.tag == "Sekkin")
        {
            if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown("joystick button 3"))
            {
                //Rigidbody2D KnockBack = other.gameObject.GetComponent<Rigidbody2D>();
                //KnockBack.AddForce(Knc);
                KnockFlag = true;
            }
            else
            {
                KnockFlag = false;
            }
        }
    }
}