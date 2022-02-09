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

    Vector2 Ref = new Vector2(5500, 0);
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

        if (Input.GetKey(KeyCode.Q) || Input.GetKey("joystick button 1"))
        {
            GetComponent<Renderer>().material.color = blue.color;
            Guard = true;
        }
        else
        {
            GetComponent<Renderer>().material.color = green.color;
            Guard = false;
        }
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
        if(other.gameObject.tag == "bullet")
        {
            if(Guard == false)
            {
                if(Input.GetKey("joystick button 1"))
                {
                    Rigidbody2D Refrb = other.gameObject.GetComponent<Rigidbody2D>();
                    Refrb.AddForce(Ref);
                }
            }
            
        }
        //if(Guard == true)
        //{
        //    if(other.gameObject.tag == "bullet")
        //    {
        //        Rigidbody2D Refrb = other.gameObject.GetComponent<Rigidbody2D>();
        //        Refrb.AddForce(Ref);
        //    }
        //}
    }
}