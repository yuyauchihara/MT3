using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy613 : MonoBehaviour
{
    public GameObject bulletPre;
    float count = 0;
    public bool changetype = true;
    GameObject Player;
    GameObject Enemy;
    [SerializeField] private float speed; // 移動スピード]
    public Vector3 PlayerPos { get; private set; }
    public Vector3 EnemyPos { get; private set; }
    public Vector3 move;

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
        
        count += Time.deltaTime;

        if (count >= 3.0f)
        {
            GameObject bullet = (GameObject)Instantiate(bulletPre, transform.position, Quaternion.identity);
            Rigidbody2D Bprb = bullet.GetComponent<Rigidbody2D>();

            // if(changetype == true)
            // {
            // Vector2 force = new Vector2(-300.0f, 0);
            // Bprb.AddForce(force);
            // }
            //else if(changetype == false)
            // {
            bullet.transform.position += move * Time.deltaTime;
            //}

            Destroy(bullet, 5f);
            count = 0;
        }
    }
    void Aim(Vector3 EnemyPos, Vector3 PlayerPos, float speed)
    {
        move = (PlayerPos - EnemyPos).normalized * speed;

    }
}