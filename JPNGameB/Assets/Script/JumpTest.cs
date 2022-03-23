using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JumpTest: MonoBehaviour
{
    //インスペクターで設定する
    public GroundCheck ground;  //接地判定
    public GroundCheck wallR;   //右壁に張り付いているか判定

    //プライベート変数
    private Rigidbody2D rb = null;
    private bool isGround = false;
    private bool isWallR = false;
    private bool pushRB = false;
    private bool Jump = false;
    //private bool lockJump = false;
    private bool canTimekasika = false;

    private float ySpeed = 0;
    private float moveSpeed = 10.5f;     //速度
    private float gravity = 5;       //重力
    private float Down = 0.3f;      //落下の加速度調整
    private float jumpSpeed = 18;    //岩を飛び越えるためのジャンプスピード
    private float JumpXSpeed = 10.0f;   //ジャンプした時の横移動の固定化
    public float jumpLimitTime; //ジャンプ制限時間
    private float jumpPos = 0.0f;
    private float jumpTime = 0.0f;
    private float jumpHeight = 100.0f;    //高さ制限
    private int count = 0;      //ジャンプの制限
    private float JumpYpos = 0.0f;  //岩の上でジャンプできないようにする変数

    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        //anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        ySpeed = -gravity;
        JumpYpos = transform.position.y;
    }

    void FixedUpdate()
    {
        var Horizontal = Input.GetAxis("Horizontal");
        //接地判定を得る
        isGround = ground.IsGround();
        isWallR = wallR.IsGround();

        //地面についているかtrueならついている
        if (isGround)
        {
            ySpeed = -gravity;
            moveSpeed = 10.5f;
            jumpTime = 0.0f;
            count = 0;
            Jump = false;
        }

        if(isWallR && Move.Pdirection == true)
        {
            if (Horizontal > 0)
            {
                moveSpeed = 0;
            }
            else
            {
                moveSpeed = 10.5f;
            }
        }
        else if(isWallR && Move.Pdirection == false)
        {
            if (Horizontal < 0)
            {
                moveSpeed = 0;
            }
            else
            {
                moveSpeed = 10.5f;
            }
        }

        //右壁にくっついた状態かの判定
        if (isWallR && Move.Pdirection == true && JumpYpos >= transform.position.y) //右
        {
            Jump = true;
            JumpXSpeed = 3.0f;
        }
        else if (isWallR && Move.Pdirection == false && JumpYpos >= transform.position.y)   //左
        {
            Jump = true;
            JumpXSpeed = -3.0f;
        }
        rb.velocity = new Vector2(Horizontal * moveSpeed, ySpeed);

        if (Jump)
        {
            bool canHeight = jumpPos + jumpHeight > transform.position.y;
            if (canHeight && count == 0)
            {
                ySpeed = jumpSpeed;
                count = 1;
                //jumpTime += Time.deltaTime;
            }
            else if (!isGround)
            {
                if (ySpeed > 1)
                {
                    ySpeed -= ySpeed * (6 * Time.deltaTime);
                }
                else
                {
                    ySpeed = Mathf.Clamp(ySpeed + -gravity * Time.deltaTime - Down, -15, 0);
                }
            }
            rb.velocity = new Vector2(JumpXSpeed, ySpeed);
        }
        //Debug.Log(canTimekasika);
    }   
}
