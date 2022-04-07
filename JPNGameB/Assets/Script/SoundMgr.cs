using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip ReflectionSound,GuardSound,ParrySound;
    public GameObject GuardArea;
    public GameObject Shield;
    ShieldGuard GuF;
    Shoei_Parry Reflct;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GuF = GuardArea.GetComponent<ShieldGuard>();
        Reflct = Shield.GetComponent<Shoei_Parry>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GuF.GuardFlag == true) //GuardAreaのShieldGuard.csのGuardFlagがtrueなら
        {
            
                audioSource.PlayOneShot(GuardSound); //一回再生する
                GuF.GuardFlag = false; //再生後falseを代入する事で連続再生を防いでる
        }

        if (Reflct.RefFlag == true) //ShieldのShoei_ParryのRefFlagがtrueなら
        {
            
                audioSource.PlayOneShot(ReflectionSound); //一回再生する
                Reflct.RefFlag = false; //再生後falseを代入する事で連続再生を防いでる
           
        }

        if(Reflct.ParyFlag == true)
        {
            audioSource.PlayOneShot(ParrySound);
            Reflct.ParyFlag = false;
        }

    }
}
