using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    Collider2D Parco;
    Rigidbody2D Parrb;

    public GameObject Player;

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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //var h = Input.GetAxis("JoyHorizontal");//横
        var v = Input.GetAxis("JoyVertical");//右スティックの縦 
        var h = Input.GetAxis("Horizontal");//左スティックの横
        Debug.Log(h);
        if (h < 0)
        {
            Player.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (0 < h)
        {
            Player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (v > 0)
        {
            i++;
        }
        if (v < 0)
        {
            i--;
        }

        if (i > 30)
        {
            i = 30;
        }
        if (i < -10)
        {
            i = -10;
        }

        if (i < 30 && i > -10)
        {
            this.transform.position += new Vector3(0, v / 40);
            transform.Rotate(new Vector3(0, 0, v));
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
        if (other.gameObject.tag == "bullet")
        {
            if (HoldShield == true)
            {
                Rigidbody2D Refrb = other.gameObject.GetComponent<Rigidbody2D>();
                Refrb.AddForce(Ref);
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
