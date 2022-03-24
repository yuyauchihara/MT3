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
        // ダメージ中は処理スキップ
        if (isDamage)
        {
            return;
        }
        if (other.gameObject.tag == "bullet" || other.gameObject.tag == "Sekkin" && !isDamage && yuya_parry2.parryf == false)
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
