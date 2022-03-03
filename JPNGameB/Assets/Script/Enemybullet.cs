using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybullet : MonoBehaviour
{
    GameObject Player;
    // public Transform Enemybullet;
    private Transform target;

    public float speed = 3.0f;  // 移動スピード]

    public Vector3 PlayerPos  { get { return Player.transform.position; } }

    // Start is called before the first frame update
    void Start()
    {
        // playerオブジェクトを取得
        this.Player = GameObject.Find("Player");
        GetComponent<Rigidbody2D>().velocity
          = new Vector2(0, speed);

        Destroy(gameObject, 3.0f);

        Vector3 PlayerPos = this.Player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        // float step = speed * Time.deltaTime;
        //Enemybullet.transform.position = Vector3.MoveTowards(Enemybullet.transform.position, Player.transform.position,step);

        float ENEMY_MOVE_SPEED = 0.05f;

        // プレイヤーの方向に移動させる
        transform.position = Vector3.MoveTowards(transform.position, PlayerPos, ENEMY_MOVE_SPEED);

    }
}