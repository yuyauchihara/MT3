using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybullet : MonoBehaviour
{
    GameObject Player;
    GameObject Enemy;
    public float speed = 3.0f; // 移動スピード]
    public Vector3 PlayerPos { get; private set; }
    public Vector3 EnemyPos { get; private set; }
    public Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        this.Player = GameObject.Find("Player");
        this.Enemy = GameObject.Find("Muzzle1");
        PlayerPos = this.Player.transform.position;
        EnemyPos = this.Enemy.transform.position;
        Aim(Enemy.transform.position, Player.transform.position, speed);
    }
    void Update()
    {
        transform.position = transform.position + move * Time.deltaTime;
    }
    void Aim(Vector3 EnemyPos, Vector3 PlayerPos, float speed)
    {
        move = (PlayerPos - EnemyPos).normalized * speed;
    }
}