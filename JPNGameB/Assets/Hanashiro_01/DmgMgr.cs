using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgMgr : MonoBehaviour
{
    // Start is called before the first frame update
    public static int Dmg = 0;

    //アニメーション用
    private Animator anim = null;
    void Start()
    {
        anim = GetComponent<Animator>(); //アニメーション用
    }

    // Update is called once per frame
    void Update()
    {
        if (Muzzle2_3.BossShot == true)
        {
            anim.SetBool("ro-buatk", true);
        }
        if(Muzzle2_3.BossShot == false)
        {
            anim.SetBool("ro-buatk", false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            Dmg++;
        }

        if (other.gameObject.tag == "HightPower")
        {
            Dmg += 2;
        }
    }

}
