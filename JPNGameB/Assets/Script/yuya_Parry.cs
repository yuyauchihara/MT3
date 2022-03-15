﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yuya_Parry : MonoBehaviour
{
    Collider2D Parco;
    Rigidbody2D Parrb;

    float RefSpeed = 10f;

    public GameObject Player;

    float H, V; //リフレクション

    public Material white;
    public Material green;

    bool parry = false;

    private bool keyIsBlock = false; //キー入力をブロックするフラグ
    private System.DateTime pressedKeyTime; //前回キー入力された時間
    private System.TimeSpan elapsedTime; //キー入力されてからの経過時間


    private System.TimeSpan blockTime = new TimeSpan(0, 0, 3); //ブロックする時間　

    Vector2 Par = new Vector2(-600.0f, 0);//パりぃーした時の弾の速度
    Vector2 Ref = new Vector2(5500, 0);

    private int i = 0;


    bool HoldShield = false;
    bool Pdirection = true; //プレイヤーの向き、trueなら左、falseなら右
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //var h = Input.GetAxis("JoyHorizontal");//横
        var v = Input.GetAxis("JoyVertical");//右スティックの縦 
        var h = Input.GetAxis("Horizontal");//左スティックの横
        var h2 = Input.GetAxis("JoyHorizontal");//右スティックの横



        if (h < 0)
        {
            Player.transform.rotation = Quaternion.Euler(0, 180, 0);
            Pdirection = false;
        }
        else if (0 < h)
        {
            Player.transform.rotation = Quaternion.Euler(0, 0, 0);
            Pdirection = true;
        }

        if (v == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        //if (Pdirection == true && v > 0 && v < 0.15)//r５度
        //{
        //    //this.transform.position += new Vector3(0, v / 40);
        //    transform.rotation = Quaternion.Euler(0, 0, 5);
        //}

        if (Pdirection == true && v > 0.16 && v < 0.3)//r10do
        {
            //this.transform.position += new Vector3(0, v / 40);
            transform.rotation = Quaternion.Euler(0, 0, 10);
        }

        //if (Pdirection == true && v > 0.31 && v < 0.45)//r15do
        //{
        //    //this.transform.position += new Vector3(0, v / 40);
        //    transform.rotation = Quaternion.Euler(0, 0, 15);
        //}

        if (Pdirection == true && v > 0.46 && v < 0.60)//r20do
        {
            //this.transform.position += new Vector3(0, v / 40);
            transform.rotation = Quaternion.Euler(0, 0, 20);
        }

        //if (Pdirection == true && v > 0.60 && v < 0.75)//r25do
        //{
        //    //this.transform.position += new Vector3(0, v / 40);
        //    transform.rotation = Quaternion.Euler(0, 0, 25);
        //}

        if (Pdirection == true && v > 0.75 && v < 1)//r30do
        {
            //this.transform.position += new Vector3(0, v / 40);
            transform.rotation = Quaternion.Euler(0, 0, 30);
        }

        //if (Pdirection == false && v > 0 && v < 1.5)//L5do
        //{
        //    //this.transform.position += new Vector3(0, v / 40);
        //    transform.rotation = Quaternion.Euler(0, 0, -5);
        //}
        
        if (Pdirection == false && v > 0.16 && v < 0.3)//L10do
        {
            //this.transform.position += new Vector3(0, v / 40);
            transform.rotation = Quaternion.Euler(0, 0, -10);
        }

        //if (Pdirection == false && v > 0.31 && v < 0.45)//L15do
        //{
        //    //this.transform.position += new Vector3(0, v / 40);
        //    transform.rotation = Quaternion.Euler(0, 0, -15);
        //}

        if (Pdirection == false && v > 0.46 && v < 0.60)//L20do
        {
            //this.transform.position += new Vector3(0, v / 40);
            transform.rotation = Quaternion.Euler(0, 0, -20);
        }

        //if (Pdirection == false && v > 0.60 && v < 0.75)//L25do
        //{
        //    //this.transform.position += new Vector3(0, v / 40);
        //    transform.rotation = Quaternion.Euler(0, 0, -25);
        //}

        if (Pdirection == false && v > 0.75 && v < 1)//L30do
        {
            //this.transform.position += new Vector3(0, v / 40);
            transform.rotation = Quaternion.Euler(0, 0, -30);
        }
        Debug.Log(v);
        //if (keyIsBlock)
        //{
        //    elapsedTime = DateTime.Now - pressedKeyTime;
        //    if (elapsedTime > blockTime)
        //    {
        //        keyIsBlock = false;
        //    }
        //    else
        //    {
        //        return;
        //    }
        //}

        if (Input.GetKeyUp("joystick button 5"))
        {
            //keyIsBlock = true;
            pressedKeyTime = DateTime.Now;

            //StartCoroutine("Parryflag");//パリィフラグのコルーチンへ
        }
        //else
        //{
        //    //GetComponent<Renderer>().material.color = green.color;
        //    parry = false;
        //}

        //ホールドシールドの判定

        if (Input.GetKey(KeyCode.Q) || Input.GetKey("joystick button 5"))
        {
            HoldShield = true;
        }
        else
        {
            HoldShield = false;
        }

        //ホールドシールドの判定終わり

        //リフレクション角度の取得
        V = Input.GetAxis("JoyVertical");//右スティックの縦 リフレクション
        H = Input.GetAxis("JoyHorizontal") * -1;//左スティックの横　リフレクション
        //リフレクション角度の取得終わり

    }

    //IEnumerator Parryflag()//パリィコルーチン
    //{
    //    GetComponent<Renderer>().material.color = white.color;//プレイヤーの色を白に
    //    parry = true;//フラグをオン
    //    yield return new WaitForSeconds(2);//二秒待つ
    //    GetComponent<Renderer>().material.color = green.color;//色を緑に
    //    parry = false;//フラグをオフ
    //}



    void OnTriggerStay2D(Collider2D other)
    {
        //var h2 = Input.GetAxis("JoyHorizontal");//右スティックの横
        //if (h2 < 0 && other.gameObject.tag == "bullet")
        //{
        //    if (HoldShield == true)
        //    {

        //        Rigidbody2D Refrb = other.gameObject.GetComponent<Rigidbody2D>();
        //        Refrb.AddForce(Ref);
        //    }
        //}
        var h2 = Input.GetAxis("JoyHorizontal");//右スティックの横

        if (other.gameObject.tag == "bullet") //リフレクション
        {
            if (HoldShield == true)
            {
                if (h2 < 0)
                {

                    Rigidbody2D Refrb = other.gameObject.GetComponent<Rigidbody2D>();
                    Refrb.velocity = new Vector2(H * -RefSpeed,0);
                }
                //Rigidbody2D Refrb = other.gameObject.GetComponent<Rigidbody2D>();
                //Refrb.velocity = new Vector2(H * RefSpeed, V * RefSpeed);
            }
        }


        //if (other.gameObject.tag == "shieldarea")
        //{
        //    this.transform.position += new Vector3(0, v / 40);
        //}

        //if (parry == true)
        //{
        //    Rigidbody2D Parrb = other.gameObject.GetComponent<Rigidbody2D>();
        //    Parrb.AddForce(Par);

        //    Collider2D Parco = other.gameObject.GetComponent<Collider2D>();
        //    Parco.isTrigger = true;
        //}

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
