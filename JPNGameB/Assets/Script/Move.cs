using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public int i = 0;

    Rigidbody2D rb;
    Rigidbody2D Refrb;
    BoxCollider2D m_ObjectCollider;
    float moveSpeed = 10.5f;
    public Material blue;
    public Material green;
    public Material black;

    public bool KillAprEnmyFlg = false; //接近する敵がスタンしてる時はTrueとなる Trueの時だけ殺せる

    //public GameObject Zahyo;
    //Text Zahyohyo;
    

    float RefSpeed = 10f; //リフレの速度

    public GameObject shield;
    public GameObject ShieldGuid;
    public GameObject ude;

    ApproachEnemy CF;

    public static bool Guard = false;
    bool RefGuard = false;
    public bool KnockFlag = false;
    bool counterflag = false;
    bool KnockBackFlg = false;

    float H, V;

    private bool keyIsBlock = false; //キー入力ブロックフラグ
    private System.DateTime pressedKeyTime; //前回キー入力された時間
    private System.TimeSpan elapsedTime; //キー入力されてからの経過時間
    public static bool parryf = false; // パリィフラグ

    private System.TimeSpan blockTime = new TimeSpan(0, 0, 3); //ブロックする時間　

    Transform EnemyPositon;

    Vector2 Ref; //反射のやつ

    Vector2 Knc = new Vector2(300, 0);

    public static bool HoldShield = false; //RBで盾を構えているか判定するフラグ 0403_public staticに変更
    public static bool Pdirection = true; //プレイヤーの向き、trueなら左、falseなら右

    public static bool GuardTime = false;//盾のクールタイム用のフラグ

    public SpriteRenderer spriteRenderer;
    public Sprite sprite;
    public Sprite sprite2;
    // Start is called before the first frame update

    //スタン系
    public static bool isStun = false;

    //スタンエフェクト関係
    public ParticleSystem StunEf;

    //スタンゲージ
    Slider StunSlider;
    float MaxStunGauge = 3.0f;

    //アニメーション用
    private Animator anim = null;

    public static bool Pmotion = false;
    public bool gardmove = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_ObjectCollider = GetComponent<BoxCollider2D>();
        shield.gameObject.SetActive(false);
        ude.gameObject.SetActive(false);
        anim = GetComponent<Animator>(); //アニメーション用

        StunSlider = GameObject.Find("StunGauge").GetComponent<Slider>();
        gardmove = false;
        Pmotion = false;
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(Pmotion);
        var h = Input.GetAxis("Horizontal");//左スティックの横
        var h2 = Input.GetAxis("JoyHorizontal");//右スティックの横 //0420_h2の型をfloatで宣言

        //Zahyohyo.text = H + "," + V.ToString();

        //rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

        //V = Input.GetAxis("JoyVertical");//右スティックの縦 リフレクション
        //H = Input.GetAxis("JoyHorizontal") * -1;//左スティックの横　リフレクション

        //Ref = new Vector2(H * 100,V * 100); //ここが毎フレーム更新されるため謎の誘導を受けている

        if (Pdirection == false)
        {
            ude.transform.localPosition = new Vector3(-0.45f, 0.078f, -5f);

        }

        if (Pdirection == true)
        {
            ude.transform.localPosition = new Vector3(-0.45f, 0.078f, 0.6f);

        }

        if (Pdirection == true && h2 > 0) //パリィ
        {
            parryf = true;
                         
        }
        else if (Pdirection == false && h2 < 0)
        {
            parryf = true;
            
        }
        else
        {
            parryf = false;
        }

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

        if(JumpTest.StunPlayer == false && Pmotion == false)
        {
            if (h < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                Pdirection = false;
            }
            else if (0 < h)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                Pdirection = true;
            }
        }

        //Vector2 force = new Vector2(0, 1f);

        //if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
        //{
        //    rb.AddForce(force);
        //}

        //if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown("joystick button 1"))
        //{
        //    //Reflection();
        //    //GetComponent<Renderer>().material.color = blue.color;
        //    //Guard = true;

        //    keyIsBlock = true;
        //    pressedKeyTime = DateTime.Now;

        //    StartCoroutine("Reflection");
        //}

        //if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown("joystick button 3"))
        //{
        //    keyIsBlock = true;
        //    pressedKeyTime = DateTime.Now;

        //    StartCoroutine("counter");
        //}

        if (Input.GetKey("joystick button 5")  && GuardTime == false || Input.GetKey(KeyCode.Q) && GuardTime == false)
        {
            ShieldGuid.gameObject.SetActive(true);
            if (JumpTest.StunPlayer == false)
            {
                HoldShield = true;
                //GetComponent<Renderer>().material.color = blue.color;
                shield.gameObject.SetActive(true);
                ude.gameObject.SetActive(true);
                moveSpeed = 5.5f;
                spriteRenderer.sprite = sprite;//画像切り替え
            }
        }

        

        if (h != 0 && Pmotion == false && gardmove == false)
        {
            anim.SetBool("run", true);
        }
        else
        {
            anim.SetBool("run", false);
        }

        if (Input.GetKey("joystick button 5") && h != 0)
        {
            anim.SetBool("gmove", true);
            gardmove = true;
        }
        else{
            anim.SetBool("gmove", false);
            gardmove = false;
        }

        if (Input.GetKeyUp(KeyCode.Q) && GuardTime == false && JumpTest.StunPlayer == false || Input.GetKeyUp("joystick button 5") && GuardTime == false && JumpTest.StunPlayer == false)
        {
            StartCoroutine(Gmotion());
            ShieldGuid.gameObject.SetActive(false);
            anim.SetBool("p_guard", true);
            GuardTime = true;
            StartCoroutine(Gcool());
        }

        //Debug.Log(moveSG.GuardCount);
        if (ShieldGuard.GuardCount >= 3)
        {
            
            isStun = true;
        }
        else
        {

            isStun = false;
        }

        if(JumpTest.StunPlayer == true) //スタン中は盾を解除,パーティクルの再生
        {           
            HoldShield = false;
            shield.gameObject.SetActive(false);
            ude.gameObject.SetActive(false);
            StunEf.Play();
            //ShieldGuard.GuardCount = 0;            
        }else if(JumpTest.StunPlayer == false)
        {
            StunEf.Stop();
        }

        float bunshi = MaxStunGauge - ShieldGuard.GuardCount;

        StunSlider.value = bunshi / MaxStunGauge;
        //Debug.Log(ShieldGuard.GuardCount);
    }

    IEnumerator Reflection()
    {
        GetComponent<Renderer>().material.color = blue.color;
        RefGuard = true;
        yield return new WaitForSeconds(2);
        GetComponent<Renderer>().material.color = green.color;
        RefGuard = false;

    }

    void OnTriggerStay2D(Collider2D other)
    {
        //if (other.gameObject.tag == "bullet") //リフレクション
        //{
        //    if (HoldShield == true)
        //    {
        //        Rigidbody2D Refrb = other.gameObject.GetComponent<Rigidbody2D>();
        //        Refrb.velocity = new Vector2(H * RefSpeed,V * RefSpeed);
        //    }
        //}
        if (Guard == false)
        {
            //if (other.gameObject.tag == "bullet")
            //{
            //    //Destroy(gameObject);
            //    Destroy(other.gameObject);
            //}
        }


        if (other.gameObject.tag == "bullet")
        {
            //Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Sekkin")
        {
            if (counterflag == true)
            {
                KnockFlag = true;
            }
        }
    }

    IEnumerator counter()
    {
        GetComponent<Renderer>().material.color = black.color;//プレイヤーの色を白に
        counterflag = true;
        yield return new WaitForSeconds(2);//二秒待つ
        GetComponent<Renderer>().material.color = green.color;//色を緑に
        counterflag = false;
    }

    IEnumerator Gcool()
    {
        ude.gameObject.SetActive(false);
        Transform tate = shield.transform;
        Pmotion = true;
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("p_guard", false);
        HoldShield = false;
        GuardTime = false;
        shield.gameObject.SetActive(false);
        
        moveSpeed = 10.5f;
        Pmotion = false;

        tate.transform.rotation = Quaternion.Euler(0, 0, 0);
        tate.transform.localPosition = new Vector2(0.05f, 0f);
    }

    IEnumerator Gmotion()
    {

        yield return new WaitForSeconds(0.1f);

        spriteRenderer.sprite = sprite2;//画像切り替え
    }
}