﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muzzle2_3 : MonoBehaviour
{
    public GameObject bulletPre;
    public GameObject HeavyBullet;
    public float BulletSped;
    public bool ChangeFlag;
    float count = 0;
    AudioSource audioSource;
    public AudioClip ShotSound;
    public float ShotSpan;
    int ShotCount = 0;

    bool colcall = false;

    int f = 0;

    private int BurstCount = 0;
    public static bool isBursted = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();       
    }

    private void FixedUpdate()
    {
        count += Time.deltaTime;
        Debug.Log(BurstCount);

        if(BurstCount >= 4)
        {
            isBursted = true;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && ShotCount < 3 && f == 0 && BurstCount <= 3)
        {
            Burst();
        }
        else if (ShotCount == 2 && f == 0)
        {
            f = 1;
            StartCoroutine("loopBurst");
        }
    }

    void Burst()
    {
        if(count >= 0.6f && ShotCount < 2)
        {
            GameObject bullet = (GameObject)Instantiate(bulletPre, transform.position, Quaternion.identity);
            ShotCount++;
            Rigidbody2D Bprb = bullet.GetComponent<Rigidbody2D>();
            audioSource.PlayOneShot(ShotSound);         
            Vector2 force = this.transform.up;
            Bprb.AddForce(force * BulletSped);            

            Destroy(bullet, 5f);
            count = 0;
        }      
    }

    IEnumerator loopBurst()
    {
        BurstCount++;
        yield return new WaitForSeconds(3.0f);
        ShotCount = 0;
        f = 0;
    }
}
