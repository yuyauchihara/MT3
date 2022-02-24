using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Jump : MonoBehaviour
{
    //インスペクターで設定する
    public float speed;         //キャラの移動速度
    public float jumpSpeed;     //ジャンプする速度
    public int Fall;            //落ちる速さ
    public int seigenJikan;     //ジャンプの時間を制限かける
    public GroundCheck ground; //接地判定

    //プライベート変数
    private Rigidbody2D rb = null;
    private bool isGround = false;  //地面の判定を取得
    private bool isJump = false;    //ジャンプしているかの判定を取得
    private int seigen = 0;         //ジャンプの制限
    private float gravity = -9.81f; //重力
    private float totalUPTime = 1f; //ジャンプ加速

    private float xSpeed = 0f;  //横移動の変数
    private float ySpeed = 0f;  //盾移動の変数


    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //接地判定を得る
        isGround = ground.IsGround();

        Vector2 force = new Vector2(0, 9000.0f);

        //キー入力されたら行動する
        float horizontalKey = Input.GetAxis("Horizontal");

        if (isGround == true)
        {
            if (isGround == true)
            {
                isJump = true;
                seigen = 0;
                totalUPTime = 1f;
                ySpeed = gravity;
            }
            else
            {
                isJump = false;
            }
        }
        if (isJump)
        {
            if (Input.GetKey/*Down*/(KeyCode.Space) && seigen <= seigenJikan)
            {
                //for (seigen = 0; seigen <= seigenJikan; seigen++)
                //{

                totalUPTime += Time.deltaTime;
                ySpeed = Mathf.Clamp((jumpSpeed * Time.deltaTime) * totalUPTime, 0, 20);
                seigen++;
                //}

                //ySpeed = jumpSpeed;

                //this.rb.AddForce(force);

                //StartCoroutine(LogCoroutine());
            }
            else
            {
                isJump = false; 
            }
        }
        else
        {
            ySpeed = -Fall;
        }
        if (horizontalKey > 0)
        {
            xSpeed = speed;
        }
        else if (horizontalKey < 0)
        {
            xSpeed = -speed;
        }
        else
        {
            xSpeed = 0.0f;
        }
                
        rb.velocity = new Vector2(xSpeed, ySpeed);
        Debug.Log(seigen);       
    }
}
