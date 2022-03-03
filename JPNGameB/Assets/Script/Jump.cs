using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Jump : MonoBehaviour
{
    //インスペクターで設定する
    public float gravity;       //重力
    public float jumpSpeed;     //ジャンプする速度
    public float jumpHeight;    //高さ制限
    public float Down = 0.5f;   //落下の加速度調整
    public GroundCheck ground;  //接地判定
    public GroundCheck wallR;   //右壁に張り付いているか判定
    public GroundCheck wallL;   //左壁に張り付いているか判定

    //プライベート変数
    //private Animator anim = null;
    private Rigidbody2D rb = null;
    private bool isGround = false;
    private bool isJump = false;
    private bool isWallR = false;
    private bool isWallL = false;
    private float jumpPos = 0.0f;
    private float ySpeed = 0;
    private float moveSpeed = 10.5f;     //速度

    //private float moveSpeed = 10.5f;

    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        //anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        ySpeed = -gravity;
    }

    void FixedUpdate()
    {
        var Horizontal = Input.GetAxis("Horizontal");
        //接地判定を得る
        isGround = ground.IsGround();
        isWallR = wallR.IsGround();
        isWallL = wallL.IsGround();
        //isHead = head.IsGround();

        //地面についているかtrueならついている
        if (isGround)
        {
            ySpeed = -gravity;
            if (Input.GetKey("joystick button 0"))
            {
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y; //ジャンプした位置を記録する
                isJump = true;
            }
            else
            {
                isJump = false;
            }
        }
        else if (isJump)    //ジャンプボタンを押している間true、制限高さを超えるとfalse
        {
            //ジャンプを押されている。かつ、現在の高さがジャンプした位置から自分の決めた位置より下ならジャンプを継続する
            if (Input.GetKey("joystick button 0") && jumpPos + jumpHeight > transform.position.y)
            {
                ySpeed = jumpSpeed;
            }
            else
            {
                isJump = false;
            }
        }
        else if(!isJump && !isGround)   //空中にいる、かつジャンプの上昇中じゃなかったら落下する処理
        {
            if (ySpeed > 1)
            {
                ySpeed -= ySpeed * (6 * Time.deltaTime);
            }
            else
            {
                ySpeed += -gravity * Time.deltaTime - Down;
            }

        }

        //右壁にくっついた状態かの判定
        if (isWallR)
        {
            if(Horizontal > 0)
            {
                moveSpeed = 0;
            }
            else
            {
                moveSpeed = 10.5f;
            }
        }
        else if(!isWallR && !isWallL)
        {
            moveSpeed = 10.5f;
        }

        //左壁にくっついた状態かの判定
        if (isWallL)
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
        else if(!isWallR && !isWallL)
        {
            moveSpeed = 10.5f;
        }

        rb.velocity = new Vector2(Horizontal * moveSpeed, ySpeed);
        Debug.Log(isJump);
    }
}
