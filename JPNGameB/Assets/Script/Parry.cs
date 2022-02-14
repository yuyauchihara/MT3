using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    Collider2D Parco;
    Rigidbody2D Parrb;

    public Material white;
    public Material green;

    bool parry = false;


    Vector2 Par = new Vector2(-900.0f, 0);
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.E) || Input.GetKey("joystick button 2")) 
        {
            GetComponent<Renderer>().material.color = white.color;
            parry = true;
        }
        else
        {
            //GetComponent<Renderer>().material.color = green.color;
            parry = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (parry == true)
        {
            Rigidbody2D Parrb = other.gameObject.GetComponent<Rigidbody2D>();
            Parrb.AddForce(Par);

            Collider2D Parco = other.gameObject.GetComponent<Collider2D>();
            Parco.isTrigger = true;
        }

        //if (other.gameObject.tag == "bullet")
        //{
        //    if (parry == false)
        //    {
        //        if (Input.GetKey("joystick button 2")) //EキーかコントローラーのXボタンでパリィ
        //        {
        //            Parco.isTrigger = true;
        //            Rigidbody2D Parrb = other.gameObject.GetComponent<Rigidbody2D>();
        //            Parrb.AddForce(Par);
        //        }
        //    }

        //}
    }
}
