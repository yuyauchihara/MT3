using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMirror : MonoBehaviour
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
        if (Muzzle2_3Mirror.BossShot == true)
        {
            anim.SetBool("ro-buatk", true);
        }
        if (Muzzle2_3Mirror.BossShot == false)
        {
            anim.SetBool("ro-buatk", false);
        }
    }
}
