using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_AproachEnemy : MonoBehaviour
{
    Rigidbody2D rb2;
    public float MoveSpeedAndDirection; //エネミーの移動速度と方向
    public float EnemyMove;　//上の変数をここに入れて移動の処理に使う
    // Start is called before the first frame update
    void Start()
    {
        rb2 = gameObject.GetComponent<Rigidbody2D>();
        EnemyMove = MoveSpeedAndDirection;
    }

    // Update is called once per frame
    void Update()
    {       
        rb2.velocity = new Vector2(EnemyMove, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "PlayerArea")
        {
            EnemyMove = 0f;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerArea")
        {
            EnemyMove = MoveSpeedAndDirection;
        }
    }
}
