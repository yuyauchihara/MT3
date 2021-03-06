using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JumpTest: MonoBehaviour
{
    //インスペクターで設定する
    public GroundCheck ground;  //接地判定
    public GroundCheck wallR;   //右壁に張り付いているか判定
    public int BattleCount = 0; //戦闘に入った時にプレイヤーの動きを止める
    public int BattleExit = 0;  //戦闘が終わった時にプレイヤーの動きを止める

    //プライベート変数
    private Rigidbody2D rb = null;
    private bool isGround = false;
    private bool isWallR = false;
    private bool pushRB = false;
    private bool Jump = false;
    //private bool lockJump = false;
    private bool canTimekasika = false;
    private bool Pstay = false;
    public bool BossMode = false;

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

    private int ugoki = 0;      //ゲームが始まった時に動きが止まるのを解消

    //スタン関係処理
    public static bool StunPlayer = false; //プレイヤーがスタンするフラグ
    public GameObject GuardArea;
    public GameObject Shield;
    //ShieldGuard SG;

    public GameObject BossObj;

    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        //anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        ySpeed = -gravity;
        JumpYpos = transform.position.y;
        ugoki = 0;
        ShieldGuard.GuardCount = 0;
        //SG = GuardArea.GetComponent<ShieldGuard>();
        Pstay = false;
        StunPlayer = false;
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
            if (!Move.HoldShield && Pstay == false)
            {
                moveSpeed = 10.5f;
            }
            if(Move.HoldShield && Pstay == false)
            {
                moveSpeed = 5.5f;
            }
            jumpTime = 0.0f;
            count = 0;
            Jump = false;
        }

        //if(isWallR && Move.Pdirection == true)
        //{
        //    if (Horizontal > 0)
        //    {
        //        moveSpeed = 0;
        //    }
        //    else
        //    {
        //        moveSpeed = 10.5f;
        //    }
        //}
        //else if(isWallR && Move.Pdirection == false)
        //{
        //    if (Horizontal < 0)
        //    {
        //        moveSpeed = 0;
        //    }
        //    else
        //    {
        //        moveSpeed = 10.5f;
        //    }
        //}

        //目の前に壁があったらジャンプを始める
        if (isWallR && Move.Pdirection == true && JumpYpos >= transform.position.y && isGround) //右
        {
            Jump = true;
            JumpXSpeed = 3.0f;
        }
        else if (isWallR && Move.Pdirection == false && JumpYpos >= transform.position.y && isGround)   //左
        {
            Jump = true;
            JumpXSpeed = -3.0f;
        }

        if (Jump)   //ジャンプ中の処理
        {
            bool canHeight = jumpPos + jumpHeight > transform.position.y;   //ジャンプできる高さを取得
            if (canHeight && count == 0)        //ジャンプできる高さかつジャンプの制限が入っていない
            {
                ySpeed = jumpSpeed;
                count = 1;
                //jumpTime += Time.deltaTime;
            }
            else if (!isGround)     //落下の処理
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
            rb.velocity = new Vector2(JumpXSpeed, ySpeed);      //ジャンプ中は勝手に動く
        }

        //ジャンプしなかったときの落下処理
        if (!isGround && !Jump)     //落下の処理
        {
            if (ySpeed > 1)
            {
                ySpeed -= ySpeed * (6 * Time.deltaTime);
            }
            else
            {
                ySpeed = Mathf.Clamp(ySpeed + -gravity * Time.deltaTime - Down, -15, 0);
            }
            rb.velocity = new Vector2(1.5f, ySpeed);
        }


        //if (Move.HoldShield == true /*&& !CameraChange.Battle*/) //盾を構えてる時の移動速度の変化
        //{
        //    moveSpeed = 5.5f;
        //}
        //else /*if(!CameraChange.Battle)*/
        //{
        //    moveSpeed = 10.5f;
        //}

        if (CameraChange.Battle == true) //敵が出てきたらプレイヤーの動きを止める
        {
            if(BattleCount > 110)
            {
                if (!Move.HoldShield && Pstay == false)
                {
                    moveSpeed = 10.5f;
                }
                else if (Move.HoldShield && Pstay == false)
                {
                    moveSpeed = 5.5f;
                }
            }
            else
            {
                moveSpeed = 0.0f;
                BattleCount++;
            }
            BattleExit = 0;
            ugoki = 1;
        }
        else if(CameraChange.Battle == false && ugoki != 0)   //敵を倒した後にプレイヤーの動きを止める
        {
            if (BattleExit > 110)
            {
                if (!Move.HoldShield && Pstay == false)
                {
                    moveSpeed = 10.5f;
                }
                else if (Move.HoldShield && Pstay == false)
                {
                    moveSpeed = 5.5f;
                }
            }
            else
            {
               if (!BossMode)
                {
                    moveSpeed = 0.0f;
                    BattleExit++;
                }
                else if (BossMode && BossObj == null)
                {
                    moveSpeed = 0.0f;
                    BattleExit++;
                }
            }
            BattleCount = 0;
        }

        if(Move.isStun == true) //スタンコルーチン開始
        {
            StartCoroutine("Stun");
        }

        if (!Jump && StunPlayer == false && isGround) //スタン処理を追加
        {
            rb.velocity = new Vector2(Horizontal * moveSpeed, ySpeed);
        }
        else if(StunPlayer == true)
        {
            rb.velocity = new Vector2(0, ySpeed);
        }

        if (Input.GetKeyUp("joystick button 5"))
        {
            StartCoroutine("Stay");
        }
    }
    
    IEnumerator Stun() //プレイヤーをスタン状態にするコルーチン
    {
        StunPlayer = true;
        //Shield.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        StunPlayer = false;
        //Shield.SetActive(true);
        ShieldGuard.GuardCount = 0;
    }

    IEnumerator Stay()
    {
        Pstay = true;
        moveSpeed = 0;
        yield return new WaitForSeconds(0.4f);
        Pstay = false;
    }
}
