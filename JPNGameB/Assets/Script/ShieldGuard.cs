using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShieldGuard : MonoBehaviour
{
    public bool GuardFlag = false;

    GameObject PlayerAtari;
    PlayerHP playerHp;

    //スタン関係
    public static int GuardCount = 0; //通常ガードの回数カウント
    public static bool isStun = false;
    public Slider StunSlider;
    int MaxStunGauge = 3;

    public SpriteRenderer sp;
    // ダメージ判定フラグ
    public static bool isDamage { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isDamage);
        if(yuya_Parry.parryf == true) //0328_本来はyuya_Parryだった　
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }

        // ダメージを受けている場合、点滅させる
        if (isDamage)
        {

            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            sp.color = new Color(1f, 1f, 1f, level);

        }

        //if(GuardCount >= 3)
        //{
        //    isStun = true;
        //}
        //else
        //{
        //    isStun = false;
        //}

        int bunshi = 3 - GuardCount;
        StunSlider.value = bunshi / MaxStunGauge;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerAtari = GameObject.Find("PlayerAtari");
        playerHp = PlayerAtari.GetComponent<PlayerHP>();

        if (isDamage)
        {
            return;
        }

        if (other.gameObject.tag == "bullet" && yuya_Parry.Parysc == false)
        {
            GuardFlag = true;
            GuardCount++; //通常ガードカウント

            //playerHp.HealthPoint -= 0.5f;

            Destroy(other.gameObject);

            //StartCoroutine(OnDamage());

            if (playerHp.HealthPoint == 0)
            {
                Invoke("ChangeScene", 1.5f);
            }

        }
    }
    void ChangeScene()
    {
        SceneManager.LoadScene("GameOver");
    }
    //public IEnumerator OnDamage()
    //{
    //    isDamage = true;
    //    yield return new WaitForSeconds(1.0f);

    //    // 通常状態に戻す
    //    isDamage = false;
    //    sp.color = new Color(1f, 1f, 1f, 1f);

    //}
}
