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
    float moveSpeed = 10.5f;
    public Material blue;
    public Material green;
    public Material black;

    public GameObject Zahyo;
    Text Zahyohyo;
    

    float RefSpeed = 10f; //リフレの速度

    public GameObject shield;

    ApproachEnemy CF;

    bool Guard = false;
    bool RefGuard = false;
    public bool KnockFlag = false;
    bool counterflag = false;
    bool KnockBackFlg = false;

    float H, V;

    private bool keyIsBlock = false; //キー入力ブロックフラグ
    private System.DateTime pressedKeyTime; //前回キー入力された時間
    private System.TimeSpan elapsedTime; //キー入力されてからの経過時間


    private System.TimeSpan blockTime = new TimeSpan(0, 0, 3); //ブロックする時間　

    public GameObject AE;
    Transform EnemyPositon;

    Vector2 Ref; //反射のやつ

    Vector2 Knc = new Vector2(300, 0);

    bool HoldShield = false; //RBで盾を構えているか判定するフラグ

    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        EnemyPositon = AE.GetComponent<Transform>();
        CF = AE.GetComponent<ApproachEnemy>();

        shield.gameObject.SetActive(false);

        Zahyohyo = Zahyo.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Zahyohyo.text = H + "," + V.ToString();

        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

        V = Input.GetAxis("JoyVertical");//右スティックの縦 
        H = Input.GetAxis("JoyHorizontal") * -1;//左スティックの横

        //Ref = new Vector2(H * 100,V * 100); //ここが毎フレーム更新されるため謎の誘導を受けている

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

        if (Input.GetKey(KeyCode.Q) || Input.GetKey("joystick button 5"))
        {
            HoldShield = true;
            GetComponent<Renderer>().material.color = blue.color;
            shield.gameObject.SetActive(true);
            moveSpeed = 5.5f;
        }
        else
        {
            HoldShield = false;
            shield.gameObject.SetActive(false);
            GetComponent<Renderer>().material.color = green.color;
            moveSpeed = 10.5f;
        }


        if (CF.counterFlag == true)
        {
            if (HoldShield == true)
            {
                KnockBackFlg = true; //こいつが引き継がれてるかも
            }
        }

        if (KnockBackFlg == true)
        {
            if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp("joystick button 5"))
            {
                KnockFlag = true;
                KnockBackFlg = false;
            }
        }

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
            //if (other.gameObject.tag == "bullet")
            //{
            //    //Destroy(gameObject);
            //    Destroy(other.gameObject);
            //}
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            if (HoldShield == true)
            {
                Rigidbody2D Refrb = other.gameObject.GetComponent<Rigidbody2D>();
                Refrb.velocity = new Vector2(H * RefSpeed,V * RefSpeed);
            }
        }

        if (other.gameObject.tag == "Sekkin")
        {
            if (counterflag == true)
            {
                KnockFlag = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Sekkin")
        {
            i = 1;
            StartCoroutine("stan");

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

    IEnumerator stan()
    {
        EnemyPositon.transform.Translate(0f, 0, 0);
        yield return new WaitForSeconds(2f);
        KnockFlag = false;
        i = 0;
    }
}