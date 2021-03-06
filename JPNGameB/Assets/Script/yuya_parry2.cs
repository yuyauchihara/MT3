using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yuya_parry2 : MonoBehaviour
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

    float radian;
    public static bool parryf = false; // パリィフラグ
    public int ShieldRote = 0;
    float sr = 0;//盾の角度の値
    float sy = 0;//盾の高さの値
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

        //Debug.Log(H);
        //Debug.Log(Move.Pdirection);
        //Debug.Log(ShieldRote);
        Debug.Log(parryf);
        if (Move.Pdirection == true && H > 0 || v == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.localPosition = new Vector2(0.8f, 0.3f);
            ShieldRote = 0;
            sr = 0;
            sy = 0;
        }

        if (Move.Pdirection == false && H < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.localPosition = new Vector2(0.8f, 0.3f);
            ShieldRote = 0;
            sr = 0;
            sy = 0;
        }


        if (Move.Pdirection == true && H < 0 && v > 0 && sy < 0.31)//盾の移動
        {
            sy = v * 0.3f;
            transform.localPosition = new Vector2(0.8f, sy + 0.3f);
        }
        if (Move.Pdirection == false && H > 0 && v > 0 && sy < 0.31)//盾の移動
        {
            sy = v * 0.3f;
            transform.localPosition = new Vector2(0.8f, sy + 0.3f);
        }


        if (Move.Pdirection == true && v > 0 && sr < 41 && H < 0)//盾の回転
        {
            sr = v * 40;
            transform.rotation = Quaternion.Euler(0, 0, sr);
        }

        if (Move.Pdirection == false && v > 0 && sr > -41 && H > 0)//盾の回転
        {
            sr = v * -40;
            transform.rotation = Quaternion.Euler(0, 0, sr);
        }

        //if ()
        //{

        //}

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

        radian = Mathf.Atan2(V, H * -1) * Mathf.Rad2Deg;

        //Debug.Log(radian);
    }

    void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "bullet") //リフレクション
        {
            GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
            if (Input.GetKeyUp("joystick button 5"))
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
                if (Move.Pdirection == true && H < 0 && sr < 41) //右向きのリフレクション
                {
                    Rigidbody2D Refrb = other.gameObject.GetComponent<Rigidbody2D>();
                    Refrb.velocity = new Vector2(Mathf.Cos(sr * Mathf.Deg2Rad) * RefSpeed, Mathf.Sin(sr * Mathf.Deg2Rad) * RefSpeed);
                }
                if (Move.Pdirection == true && H <= 0 && sr == 40)
                {
                    Rigidbody2D Refrb = other.gameObject.GetComponent<Rigidbody2D>();
                    Refrb.velocity = new Vector2(Mathf.Cos(40 * Mathf.Deg2Rad) * RefSpeed, Mathf.Sin(40 * Mathf.Deg2Rad) * RefSpeed);
                }

                if (Move.Pdirection == false && H > 0 && sr > -41) //左向きのリフレクション
                {
                    Rigidbody2D Refrb = other.gameObject.GetComponent<Rigidbody2D>();
                    Refrb.velocity = new Vector2(Mathf.Cos(radian * Mathf.Deg2Rad) * RefSpeed, Mathf.Sin(radian * Mathf.Deg2Rad) * RefSpeed);
                }

                if (Move.Pdirection == false && H >= 0 && sr == -40)
                {
                    Rigidbody2D Refrb = other.gameObject.GetComponent<Rigidbody2D>();
                    Refrb.velocity = new Vector2(Mathf.Cos(40 * Mathf.Deg2Rad) * -RefSpeed, Mathf.Sin(40 * Mathf.Deg2Rad) * RefSpeed);
                }

                if (Move.Pdirection == true && H > 0) //パリィ
                {
                    Rigidbody2D Refrb = other.gameObject.GetComponent<Rigidbody2D>();
                    Refrb.velocity = new Vector2(1 * RefSpeed * -1, 0);
                    parryf = true;
                }
                else if (Move.Pdirection == false && H < 0)
                {
                    Rigidbody2D Refrb = other.gameObject.GetComponent<Rigidbody2D>();
                    Refrb.velocity = new Vector2(1 * RefSpeed, 0);
                    parryf = true;
                }
                else
                {
                    parryf = false;
                }
            }

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            GetComponent<SpriteRenderer>().color = new Color(0, 220, 255);
        }
    }
}
