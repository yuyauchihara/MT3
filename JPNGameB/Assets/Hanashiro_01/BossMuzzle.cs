using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMuzzle : MonoBehaviour
{
    public GameObject bulletPre;
    public float BulletSped;
    float count = 0;
    AudioSource audioSource;
    public AudioClip ShotSound;
    public float ShotSpan;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        count += Time.deltaTime;


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (count >= ShotSpan && collision.gameObject.tag == "Player" && StageMgr.isBossAttack == true)
        {
            GameObject bullet = (GameObject)Instantiate(bulletPre, transform.position, Quaternion.identity);
            Rigidbody2D Bprb = bullet.GetComponent<Rigidbody2D>();

            audioSource.PlayOneShot(ShotSound);

            Vector2 force = this.transform.up;
            Bprb.AddForce(force * BulletSped);

            Destroy(bullet, 5f);
            count = 0;
            StageMgr.isBossAttack = false;
        }
    }
}