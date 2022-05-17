using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// CanvasGroupコンポーネントがアタッチされていない場合、アタッチ
[RequireComponent(typeof(CanvasGroup))]
public class TitleT : MonoBehaviour
{
    public SpriteRenderer sp;

    void Update()
    {
        float level = Mathf.Abs(Mathf.Sin(Time.time * 3));
        sp.color = new Color(1f, 1f, 1f, level);
    }
}