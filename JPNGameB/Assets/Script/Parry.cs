using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
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

    private int  i = 0;

    bool HoldShield = false;
    bool Pdirection = true; //プレイヤーの向き、trueなら左、falseなら右

    float radian;
    public static bool parryf = false; // パリィフラグ
    void Start()
    {
        Application.targetFrameRate = 50;
    }

    // Update is called once per frame
    void Update()
    {
        //var h = Input.GetAxis("JoyHorizontal");//横
        var v = Input.GetAxis("JoyVertical");//右スティックの縦 
        var h = Input.GetAxis("Horizontal");//左スティックの横
        var h2 = Input.GetAxis("JoyHorizontal");//右スティックの横


        if (v == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        //if (Pdirection == true && v > 0 && v < 0.15)//r５度
        //{
        //    //this.transform.position += new Vector3(0, v / 40);
        //    transform.rotation = Quaternion.Euler(0, 0, 5);
        //}

        if (Move.Pdirection == true && v > 0.16 && v < 0.3 && h2 < 0)//r10do
        {
            //this.transform.position += new Vector3(0, v / 40);
            transform.rotation = Quaternion.Euler(0, 0, 10);
        }

        //if (Pdirection == true && v > 0.31 && v < 0.45)//r15do
        //{
        //    //this.transform.position += new Vector3(0, v / 40);
        //    transform.rotation = Quaternion.Euler(0, 0, 15);
        //}

        if (Move.Pdirection == true && v > 0.46 && v < 0.60 && h2 < 0)//r20do
        {
            //this.transform.position += new Vector3(0, v / 40);
            transform.rotation = Quaternion.Euler(0, 0, 20);
        }

        //if (Pdirection == true && v > 0.60 && v < 0.75)//r25do
        //{
        //    //this.transform.position += new Vector3(0, v / 40);
        //    transform.rotation = Quaternion.Euler(0, 0, 25);
        //}

        if (Move.Pdirection == true && v > 0.75 && v < 1 && h2 < 0)//r30do
        {
            //this.transform.position += new Vector3(0, v / 40);
            transform.rotation = Quaternion.Euler(0, 0, 30);
        }

        //if (Pdirection == false && v > 0 && v < 1.5)//L5do
        //{
        //    //this.transform.position += new Vector3(0, v / 40);
        //    transform.rotation = Quaternion.Euler(0, 0, -5);
        //}

        if (Move.Pdirection == false && v > 0.16 && v < 0.3 && h2 > 0)//L10do
        {
            //this.transform.position += new Vector3(0, v / 40);
            transform.rotation = Quaternion.Euler(0, 0, -10);
        }

        //if (Pdirection == false && v > 0.31 && v < 0.45)//L15do
        //{
        //    //this.transform.position += new Vector3(0, v / 40);
        //    transform.rotation = Quaternion.Euler(0, 0, -15);
        //}

        if (Move.Pdirection == false && v > 0.46 && v < 0.60 && h2 > 0)//L20do
        {
            //this.transform.position += new Vector3(0, v / 40);
            transform.rotation = Quaternion.Euler(0, 0, -20);
        }

        //if (Pdirection == false && v > 0.60 && v < 0.75)//L25do
        //{
        //    //this.transform.position += new Vector3(0, v / 40);
        //    transform.rotation = Quaternion.Euler(0, 0, -25);
        //}

        if (Move.Pdirection == false && v > 0.75 && v < 1 && h2 > 0)//L30do
        {
            //this.transform.position += new Vector3(0, v / 40);
            transform.rotation = Quaternion.Euler(0, 0, -30);
        }
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
        V = Input.GetAxisRaw("JoyVertical");//右スティックの縦 リフレクション
        H = Input.GetAxisRaw("JoyHorizontal");//左スティックの横　リフレクション
        //リフレクション角度の取得終わり

        radian = Mathf.Atan2(V, H*-1) * Mathf.Rad2Deg;

        Debug.Log(radian);
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

        if (other.gameObject.tag == "bullet") //リフレクション
        {
            GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
            //testrefStart
            if(Input.GetKeyUp("joystick button 5"))
            {
                if (Move.Pdirection == true && V == 0 && H == 0)　//右向きのリフレクション(入力無し)
                {
                    Rigidbody2D Refrb = other.gameObject.GetComponent<Rigidbody2D>();
                    Refrb.velocity = new Vector2(1 * RefSpeed, 0 * RefSpeed);
                }
                if (Move.Pdirection == false && V == 0 && H == 0)　//左向きのリフレクション(入力無し)
                {
                    Rigidbody2D Refrb = other.gameObject.GetComponent<Rigidbody2D>();
                    Refrb.velocity = new Vector2(1 * -RefSpeed, 0 * RefSpeed);
                }
                if (H < 0) //リフレクション
                {
                    Rigidbody2D Refrb = other.gameObject.GetComponent<Rigidbody2D>();
                    Refrb.velocity = new Vector2(Mathf.Cos(radian * Mathf.Deg2Rad) * RefSpeed, Mathf.Sin(radian * Mathf.Deg2Rad) * RefSpeed);
                }

                if (H > 0) //パリィ
                {
                    Rigidbody2D Refrb = other.gameObject.GetComponent<Rigidbody2D>();
                    Refrb.velocity = new Vector2(H * RefSpeed * -1, 0);
                    parryf = true;
                }
                else
                {
                    parryf = false;
                }

            }
            //testrefFinish

            if (HoldShield == true)
            {
                //if (Move.Pdirection == true && V == 0 && H == 0)　//リフレクション(入力無し)
                //{
                //    Rigidbody2D Refrb = other.gameObject.GetComponent<Rigidbody2D>();
                //    Refrb.velocity = new Vector2(1 * RefSpeed, 0 * RefSpeed);
                //}
                //if (Move.Pdirection == false && V == 0 && H == 0)　//リフレクション(入力無し)
                //{
                //    Rigidbody2D Refrb = other.gameObject.GetComponent<Rigidbody2D>();
                //    Refrb.velocity = new Vector2(1 * -RefSpeed, 0 * RefSpeed);
                //}
                //if (H < 0) //リフレクション
                //{
                //    Rigidbody2D Refrb = other.gameObject.GetComponent<Rigidbody2D>();
                //    Refrb.velocity = new Vector2(Mathf.Cos(radian * Mathf.Deg2Rad) * RefSpeed, Mathf.Sin(radian * Mathf.Deg2Rad) * RefSpeed);
                //}
                //if (H > 0) //パリィ
                //{
                //    Rigidbody2D Refrb = other.gameObject.GetComponent<Rigidbody2D>();
                //    Refrb.velocity = new Vector2(H * RefSpeed * -1, 0);
                //    parryf = true;
                //}
                //else
                //{
                //    parryf = false;
                //}
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

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "bullet")
        {
            GetComponent<SpriteRenderer>().color = new Color(0, 220, 255);
        }
    }
}
