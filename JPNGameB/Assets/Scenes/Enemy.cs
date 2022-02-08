using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bulletPre;
    float count = 0;

    void Start()
    {

    }

    void Update()
    {

        count += Time.deltaTime;

        if (count >= 3.0f)
        {
            GameObject bullet = (GameObject)Instantiate(bulletPre, transform.position, Quaternion.identity);
            Rigidbody2D Bprb = bullet.GetComponent<Rigidbody2D>();
            Vector2 force = new Vector2(-5500.0f, 0);
            Bprb.AddForce(force);
            Destroy(bullet, 5f);
            count = 0;
        }
    }
}