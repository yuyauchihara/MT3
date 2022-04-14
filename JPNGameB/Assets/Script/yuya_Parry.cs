using System;
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
    bool parry = false;

    private bool keyIsBlock = false; //キー入力をブロックするフラグ
    private System.DateTime pressedKeyTime; //前回キー入力された時間
    private System.TimeSpan elapsedTime; //キー入力されてからの経過時間


    private System.TimeSpan blockTime = new TimeSpan(0, 0, 1); //ブロックする時間　

    Vector2 Par = new Vector2(-600.0f, 0);//パりぃーした時の弾の速度
    Vector2 Ref = new Vector2(5500, 0);

    private int i = 0;

    bool HoldShield = false;
    bool Pdirection = true; //プレイヤーの向き、trueなら左、falseなら右

    float radian;
    public static bool parryf = false; // パリィフラグ
    public bool RefFlag; //リフレクションフラグ音声用
    public bool ParyFlag = false; //パリィフラグ音声用
    public static bool Parysc = false;
    public int ShieldRote = 0;
    float sr = 0;//盾の角度の値
    float sy = 0;//盾の高さの値

    //public SpriteRenderer spriteRenderer;
    //public Sprite sprite;
    //public Sprite sprite2;

    public GameObject GuardArea;
    ShieldGuard SG;

    void Start()
    {
        parryf = false;
        Application.targetFrameRate = 50;
        SG = GuardArea.GetComponent<ShieldGuard>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Parysc);
        //var h = Input.GetAxis("JoyHorizontal");//横
        var v = Input.GetAxis("JoyVertical");//右スティックの縦 
        var h = Input.GetAxis("Horizontal");//左スティックの横
        var h2 = Input.GetAxis("JoyHorizontal");//右スティックの横

        //Debug.Log(H);
        //Debug.Log(Move.Pdirection);
        //Debug.Log(ShieldRote);
        //Debug.Log(parryf);
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

        if (Move.Pdirection == true && v == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.localPosition = new Vector2(0.04f, 0f);
            ShieldRote = 0;
            sr = 0;
            sy = 0;
        }

        if (Move.Pdirection == false && v == 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.localPosition = new Vector2(0.04f, 0f);
            ShieldRote = 0;
            sr = 0;
            sy = 0;
        }



        if (Move.Pdirection == true && H < 0 && v > 0 && sy < 0.31)//盾の移動
        {
            sy = v * 0.3f;
            transform.localPosition = new Vector2(0.04f, sy + 0f);
        }
        if (Move.Pdirection == false && H > 0 && v > 0 && sy < 0.31)//盾の移動
        {
            sy = v * 0.3f;
            transform.localPosition = new Vector2(0.04f, sy + 0f);
        }

        if (Move.Pdirection == true && v > 0 && sr < 41 && H < 0)//盾の回転
        {
            sr = v * 40;
            transform.rotation = Quaternion.Euler(0, 0, sr);
        }

        if (Move.Pdirection == false && v > 0 && sr > -41 && H > 0)//盾の回転
        {
            sr = v * -40;
            transform.rotation = Quaternion.Euler(0, 180, -sr);
        }


        if (Move.Pdirection == true && H < 0 || Move.Pdirection == false && H > 0)
        {
            Parysc = false;
        }

        //if (Input.GetKey("joystick button 5") && Move.GuardTime == false || Input.GetKey(KeyCode.Q) && Move.GuardTime == false)
        //{
        //    spriteRenderer.sprite = sprite;
        //}

        if (Input.GetKeyUp("joystick button 5") && Move.GuardTime == false || Input.GetKeyUp(KeyCode.Q) && Move.GuardTime == false)//リフレクションなどのモーション
        {
            //spriteRenderer.sprite = sprite2;//画像切り替え
            

            StartCoroutine(cooltime());
        }

        if (Move.GuardTime == true)
        {
            transform.localPosition = new Vector3(-0.2f, sy + 0f, -2f);
        }

        //if ()
        //{

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
            if (Input.GetKeyUp("joystick button 5") || Input.GetKeyUp(KeyCode.Q))
            {
                SG.GuardCount = 0;
                if (Move.Pdirection == true && Move.GuardTime == false)//プレイヤーが右向き
                {
                    if (V == 0 && H == 0) //右向きのリフレクション(入力無し)
                    {
                        Rigidbody2D Refrb = other.gameObject.GetComponent<Rigidbody2D>();
                        Refrb.velocity = new Vector2(1 * RefSpeed, 0 * RefSpeed);
                        RefFlag = true; //音声再生で使用、SoundMgr.csと共有
                    }

                    if (H < 0 && sr < 41) //右向きのリフレクション
                    {
                        RefFlag = true; //音声再生で使用、SoundMgr.csと共有
                        Rigidbody2D Refrb = other.gameObject.GetComponent<Rigidbody2D>();
                        Refrb.velocity = new Vector2(Mathf.Cos(sr * Mathf.Deg2Rad) * RefSpeed, Mathf.Sin(sr * Mathf.Deg2Rad) * RefSpeed);
                    }

                    if (H <= 0 && sr == 40)
                    {
                        RefFlag = true; //音声再生で使用、SoundMgr.csと共有
                        Rigidbody2D Refrb = other.gameObject.GetComponent<Rigidbody2D>();
                        Refrb.velocity = new Vector2(Mathf.Cos(40 * Mathf.Deg2Rad) * RefSpeed, Mathf.Sin(40 * Mathf.Deg2Rad) * RefSpeed);
                    }
                }

                if (Move.Pdirection == false && Move.GuardTime == false)//プレイヤーが左向き
                {
                    if (V == 0 && H == 0) //左向きのリフレクション(入力無し)
                    {
                        Rigidbody2D Refrb = other.gameObject.GetComponent<Rigidbody2D>();
                        Refrb.velocity = new Vector2(1 * -RefSpeed, 0 * RefSpeed);
                        RefFlag = true; //音声再生で使用、SoundMgr.csと共有
                    }

                    if (H > 0 && sr > -41) //左向きのリフレクション
                    {
                        RefFlag = true; //音声再生で使用、SoundMgr.csと共有
                        Rigidbody2D Refrb = other.gameObject.GetComponent<Rigidbody2D>();
                        Refrb.velocity = new Vector2(Mathf.Cos(radian * Mathf.Deg2Rad) * RefSpeed, Mathf.Sin(radian * Mathf.Deg2Rad) * RefSpeed);
                    }

                    if (H >= 0 && sr == -40)
                    {
                        RefFlag = true; //音声再生で使用、SoundMgr.csと共有
                        Rigidbody2D Refrb = other.gameObject.GetComponent<Rigidbody2D>();
                        Refrb.velocity = new Vector2(Mathf.Cos(40 * Mathf.Deg2Rad) * -RefSpeed, Mathf.Sin(40 * Mathf.Deg2Rad) * RefSpeed);
                    }

                }

                if (Move.Pdirection == true && H > 0) //パリィ
                {
                    Rigidbody2D Refrb = other.gameObject.GetComponent<Rigidbody2D>();
                    Refrb.velocity = new Vector2(1 * RefSpeed * -1, 0);
                    ParyFlag = true; //音声の為のフラグ SoundMgr.csと共有
                    Parysc = true;
                }

                if (Move.Pdirection == false && H < 0)
                {
                    Rigidbody2D Refrb = other.gameObject.GetComponent<Rigidbody2D>();
                    Refrb.velocity = new Vector2(1 * RefSpeed, 0);
                    ParyFlag = true; //音声の為のフラグ SoundMgr.csと共有
                    Parysc = true;
                }

            }

        }

        if (other.gameObject.tag == "Sekkin")
        {
            GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
            if (Input.GetKeyUp("joystick button 5") || Input.GetKeyUp(KeyCode.Q))
            {
                if (Move.GuardTime == false)
                {
                    other.GetComponent<New_AproachEnemy>().isKnockBack = true;
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

        if (other.gameObject.tag == "Sekkin")
        {
            GetComponent<SpriteRenderer>().color = new Color(0, 220, 255);
        }

    }

    IEnumerator cooltime()
    {
        yield return new WaitForSeconds(0.5f);

        Parysc = false;
        
    }
}
