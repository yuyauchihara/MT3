using System;
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

    private bool keyIsBlock = false; //キー入力ブロックフラグ
    private System.DateTime pressedKeyTime; //前回キー入力された時間
    private System.TimeSpan elapsedTime; //キー入力されてからの経過時間


    private System.TimeSpan blockTime = new TimeSpan(0, 0, 3); //ブロックする時間　1s

    Vector2 Par = new Vector2(-900.0f, 0);
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (keyIsBlock)
        {
            elapsedTime = DateTime.Now - pressedKeyTime;
            if (elapsedTime > blockTime)
            {
                keyIsBlock = false;
            }
            else
            {
                return;
            }
        }

        if (Input.GetKey(KeyCode.E) || Input.GetKey("joystick button 2")) 
        {
            keyIsBlock = true;
            pressedKeyTime = DateTime.Now;

            StartCoroutine("Parryflag");//パリィフラグのコルーチンへ
            //GetComponent<Renderer>().material.color = white.color;
            //parry = true;
        }
        //else
        //{
        //    //GetComponent<Renderer>().material.color = green.color;
        //    parry = false;
        //}
    }

    IEnumerator Parryflag()//パリィコルーチン
    {
        GetComponent<Renderer>().material.color = white.color;//プレイヤーの色を白に
        parry = true;//フラグをオン
        yield return new WaitForSeconds(2);//二秒待つ
        GetComponent<Renderer>().material.color = green.color;//色を緑に
        parry = false;//フラグをオフ
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
