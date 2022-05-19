using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorBoss : MonoBehaviour
{
    private Animator anim = null;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); //アニメーション用
    }

    // Update is called once per frame
    void Update()
    {
        if(Muzzle2_3.BossShot == true)
        {
            anim.SetBool("Mirroratk", true);
        }
        if (Muzzle2_3.BossShot == false)
        {
            anim.SetBool("Mirroratk", false);
        }
    }
}
