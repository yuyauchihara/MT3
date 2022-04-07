using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_AproachEnemy : MonoBehaviour
{
    Rigidbody2D rb2;
    public float MoveSpeedAndDirection; //エネミーの移動速度と方向
    public float EnemyMove;　//上の変数をここに入れて移動の処理に使う
    public static bool isAttack = false;
    public static int Direction;
    public bool isKnockBack = false;
    public static bool StanFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2 = gameObject.GetComponent<Rigidbody2D>();
        EnemyMove = MoveSpeedAndDirection;

        if(MoveSpeedAndDirection > 0)
        {
            Direction = 1;
        }
        else
        {
            Direction = -1;
        }

    }

    // Update is called once per frame
    void Update()
    {       
        rb2.velocity = new Vector2(EnemyMove, 0);

        if(isAttack == true)
        {
            EnemyMove = -Direction * 1.5f;
        }
        if(AttackArea.isInAttackArea == false)
        {
            isAttack = false;
            EnemyMove = MoveSpeedAndDirection;
        }

        if(isKnockBack == true) //機能している_ここにノックバック用の処理を書け
        {
            StartCoroutine("KnockBack");
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "PlayerArea" && isAttack == false)
        {
            //EnemyMove = 0f;
            isAttack = true;   
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerArea")
        {
            //EnemyMove = MoveSpeedAndDirection;
            //isAttack = false;
        }
    }

    IEnumerator KnockBack()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(8f, 0);
        yield return new WaitForSeconds(0.5f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        StanFlag = true;
        yield return new WaitForSeconds(1.5f);
        isKnockBack = false;
        StanFlag = false;
    }

}
