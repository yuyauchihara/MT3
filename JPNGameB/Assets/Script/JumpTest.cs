using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTest : MonoBehaviour
{
    private Rigidbody2D rbody2D;

    public float jumpForce = 250f;

    private int jumpCount = 0;

    private bool keyIsBlock = false; //キー入力をブロックするフラグ
    private System.DateTime pressedKeyTime; //前回キー入力された時間
    private System.TimeSpan elapsedTime; //キー入力されてからの経過時間
    private System.TimeSpan blockTime = new TimeSpan(0, 0, 1); //ブロックする時間

    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown("joystick button 0") && this.jumpCount < 1 || Input.GetKeyDown(KeyCode.Space) && this.jumpCount < 1)
        {
            keyIsBlock = true;
            pressedKeyTime = DateTime.Now;
            this.rbody2D.AddForce(transform.up * jumpForce);
            jumpCount++;
        }
        if (keyIsBlock)
        {
            elapsedTime = DateTime.Now - pressedKeyTime;
            if (elapsedTime > blockTime)
            {
                keyIsBlock = false;
            }
            else
            {
              return;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("stage"))
        {
            jumpCount = 0;
        }
    }
}