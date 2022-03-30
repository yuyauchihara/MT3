using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public Slider Tairyoku;
    public AudioClip HitPlayerSound;
    AudioSource audioSource;
    float HealthPoint = 10.0f;
    float MaxHP = 10.0f;

    public static bool HoldShield = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q) || Input.GetKey("joystick button 5"))
        {
            HoldShield = true;
        }
        else
        {
            HoldShield = false;
        }
        Tairyoku.value = HealthPoint / MaxHP;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "bullet" && !PlayerDamage.isDamage) //銃撃によるダメージ
        {
           
            if (Shoei_Parry.parryf == false) //0327_テストの為フラグをShoei_Parryに一時的に変更した。本来はyuya_parry2.parryf
            {
                HealthPoint--;
                audioSource.PlayOneShot(HitPlayerSound); //被弾音再生
                Destroy(other.gameObject);
            }
            
        }
        if (other.gameObject.tag == "Sekkin" && !PlayerDamage.isDamage) //近接攻撃によるダメージ
        {

            if (Shoei_Parry.parryf == false) //0327_テストの為フラグをShoei_Parryに一時的に変更した。本来はyuya_parry2.parryf
            {
                HealthPoint--;
            }

        }


    }
}
