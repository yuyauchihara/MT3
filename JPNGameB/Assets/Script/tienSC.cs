using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tienSC : MonoBehaviour
{
    [SerializeField] private GameObject Canvas;

    private int CanvasTimer = 0;
    public float CanvasTime = 0f;      //設定秒数で表示

    void Start()
    {
        Canvas.SetActive(false);
        CanvasTime *= 60;
    }

    void FixedUpdate()
    {
        if (CanvasTimer < CanvasTime)
        {
            CanvasTimer++;
        }else
        {
            Canvas.SetActive(true);
        }
    }
}
