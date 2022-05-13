using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    Slider Tairyoku;
    public AudioClip HitPlayerSound;
    AudioSource audioSource;
    ShieldGuard shieldGuard;
    public float HealthPoint = 10.0f;
    float MaxHP = 10.0f;

    public static bool HoldShield = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        shieldGuard = GetComponent<ShieldGuard>();

        Tairyoku = GameObject.Find("HP").GetComponent<Slider>();
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
        var h2 = Input.GetAxis("JoyHorizontal");//右スティックの横
        if (other.gameObject.tag == "bullet" && !PlayerDamage.isDamage) //銃撃によるダメージ
        {
            if (Move.parryf == false)
            {
                HealthPoint--;
                audioSource.PlayOneShot(HitPlayerSound); //被弾音再生
                Destroy(other.gameObject);
                if (HealthPoint == 0)
                {
                    Invoke("ChangeScene", 2.0f);
                }
            }
        }
        if (other.gameObject.tag == "bullet" && Move.Pdirection == true && h2 > 0 && yuya_Parry.Parysc == false)
        {
            HealthPoint--;
            audioSource.PlayOneShot(HitPlayerSound); //被弾音再生
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "bullet" && Move.Pdirection == false && h2 < 0 && yuya_Parry.Parysc == false)
        {
            HealthPoint--;
            audioSource.PlayOneShot(HitPlayerSound); //被弾音再生
            Destroy(other.gameObject);
        }



        if (other.gameObject.tag == "HightPower" && !PlayerDamage.isDamage) //強装弾によるダメージ
        {
            if (Move.parryf == false)
            {
                HealthPoint -= 2;
                audioSource.PlayOneShot(HitPlayerSound); //被弾音再生
                Destroy(other.gameObject);
                if (HealthPoint == 0)
                {
                    Invoke("ChangeScene", 2.0f);
                }
            }
        }
        if (other.gameObject.tag == "HightPower" && Move.Pdirection == true && h2 > 0 && yuya_Parry.Parysc == false)
        {
            HealthPoint -= 2;
            audioSource.PlayOneShot(HitPlayerSound); //被弾音再生
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "HightPower" && Move.Pdirection == false && h2 < 0 && yuya_Parry.Parysc == false)
        {
            HealthPoint -= 2;
            audioSource.PlayOneShot(HitPlayerSound); //被弾音再生
            Destroy(other.gameObject);
        }



        if (other.gameObject.tag == "Sekkin" && !PlayerDamage.isDamage) //近接攻撃によるダメージ 
        {

            if (Move.parryf == false && Move.HoldShield == false) //0403_&& Move.HoldShield == false
            {
                HealthPoint--;
            }

        }
    }
    void ChangeScene()
    {
        CameraChange.Battle = false;
        SceneManager.LoadScene("GameOver");
    }
}