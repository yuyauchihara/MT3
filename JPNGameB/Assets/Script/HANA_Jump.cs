using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HANA_Jump : MonoBehaviour
{
    //インスペクターで設定する
    public float jumpSpeed;     //ジャンプする速度
    public float jumpHeight;    //高さ制限
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
    private bool pushRB = false;
    private bool pushJump = false;

    private float jumpPos = 0.0f;
    private float ySpeed = 0;
    private float moveSpeed = 10.5f;     //速度
    private float gravity = 5;       //重力
    private float Down = 0.3f;   //落下の加速度調整
    private float RBCountTime = 0f; //落下速度低下の制限時間1秒
    private float RBCount = 0;      //RBの連続入力阻止
    private float JumpBlock = 0;


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

        //RBが押されているかの判定
        if (Input.GetKey("joystick button 5"))
        {
            pushRB = true;
        }
        else
        {
            pushRB = false;
        }

        if (Input.GetKey("joystick button 0"))
        {
            pushJump = true;
        }
        else
        {
            pushJump = false;
        }

        //地面についているかtrueならついている
        if (isGround)
        {
            ySpeed = -gravity;
            RBCountTime = 0;
            RBCount = 0;

            if (!pushJump)
            {
                JumpBlock = 0;
            }

            if (Input.GetKey("joystick button 0") && JumpBlock == 0)
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
            if (Input.GetKey("joystick button 0") && jumpPos + jumpHeight > transform.position.y && JumpBlock == 0)
            {
                ySpeed = jumpSpeed;
            }
            else
            {
                isJump = false;
            }
        }
        else if (!isJump && !isGround)   //空中にいる、かつジャンプの上昇中じゃなかったら落下する処理
        {
            if (ySpeed > 1)
            {
                ySpeed -= ySpeed * (6 * Time.deltaTime);
                JumpBlock = 1;
            }
            else
            {
                //空中でRBを押したときの処理
                if (pushRB && RBCountTime < 60)
                {

                    if (RBCount == 0)
                    {
                        ySpeed = 0.2f;
                        moveSpeed = 0.0f;
                        RBCountTime++;
                    }
                }
                else if (RBCount != 0 && !pushRB)
                {
                    RBCount++;
                }
                ySpeed = Mathf.Clamp(ySpeed + -gravity * Time.deltaTime - Down, -15, 0);
            }

        }

        //右壁にくっついた状態かの判定
        if (isWallR)
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
        else if (!isWallR && !isWallL && !isJump && isGround)
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
        else if (!isWallR && !isWallL && !isJump && isGround)
        {
            moveSpeed = 10.5f;
        }

        //花城_移動速度の変更ここから
        if (Input.GetKey(KeyCode.Q) || Input.GetKey("joystick button 5"))
        {
            moveSpeed = 5.5f;
        }
        else
        {
            moveSpeed = 10.5f;
        }
        //花城_移動速度の変更ここまで

        rb.velocity = new Vector2(Horizontal * moveSpeed, ySpeed); //花城_移動の処理
        Debug.Log(RBCount);
    }
}
