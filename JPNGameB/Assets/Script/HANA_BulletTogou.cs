using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HANA_BulletTogou : MonoBehaviour
{
    public GameObject bulletPre;
    public float BulletSped;
    public bool ChangeFlag;
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

            if (ChangeFlag == true)
            {
                Vector2 force = new Vector2(BulletSped, 0f);
                Bprb.AddForce(force);
            }
            else //false
            {
                Vector2 force = this.transform.up;
                //Bprb.velocity = this.transform.up * BulletSped;
                Bprb.AddForce(force * BulletSped);
            }

            Destroy(bullet, 5f);
            count = 0;
        }
    }
}