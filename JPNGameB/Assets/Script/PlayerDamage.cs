using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public SpriteRenderer sp;
    // ダメージ判定フラグ
    public static bool isDamage { get; set; }

    
    void Update()
    {
        
        // ダメージを受けている場合、点滅させる
        if (isDamage)
        {

            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            sp.color = new Color(1f, 1f, 1f, level);

        }

    }

    // トリガー発生時
    private void OnTriggerEnter2D(Collider2D other)
    {
        var h2 = Input.GetAxis("JoyHorizontal");//右スティックの横
        // ダメージ中は処理スキップ
        if (isDamage)
        {
            return;
        }
        if (other.gameObject.tag == "bullet" && Move.parryf == false || other.gameObject.tag == "Sekkin" && !isDamage && Move.parryf == false && Move.HoldShield == false) //0331_yuya.parry2からShoei_Parryに一時的に変更 0403_&& Move.HoldShield == falseを追加

        {
            StartCoroutine(OnDamage());
        }

        if (other.gameObject.tag == "bullet" && Move.Pdirection == true && h2 > 0 && Shoei_Parry.Parysc == false)
        {
            StartCoroutine(OnDamage());
        }
        if (other.gameObject.tag == "bullet" && Move.Pdirection == false && h2 < 0 && Shoei_Parry.Parysc == false)
        {
            StartCoroutine(OnDamage());
        }
    }

    public IEnumerator OnDamage()
    {
        isDamage = true;
        yield return new WaitForSeconds(1.0f);

        // 通常状態に戻す
        isDamage = false;
        sp.color = new Color(1f, 1f, 1f, 1f);

    }

}
