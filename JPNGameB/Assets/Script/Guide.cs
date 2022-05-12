using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{
    //public SpriteRenderer sp;
    // ダメージ判定フラグ
    float H;
    float sr = 0;
    void Start()
    {
        
    }

    void Update()
    {
        var h = Input.GetAxis("Horizontal");//左スティックの横
        var v = Input.GetAxis("JoyVertical");//右スティックの縦 
        var h2 = Input.GetAxis("JoyHorizontal");//右スティックの横
        H = Input.GetAxisRaw("JoyHorizontal");//左スティックの横　リフレクション
        //if (Input.GetKey("joystick button 5"))
        //{
        //    float level = Mathf.Abs(Mathf.Sin(Time.time * 2));
        //    sp.color = new Color(1f, 1f, 1f, level);
        //}
        //else
        //{
        //    sp.color = new Color(1f, 1f, 1f, 1f);
        //}

        if (Move.Pdirection == false && v == 0)
        {
            transform.localPosition = new Vector2(0.7f, 0);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (Move.Pdirection == true && v == 0)
        {
            transform.localPosition = new Vector2(0.7f, 0);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (Move.Pdirection == false && v > 0 && H > 0)
        {
            
            transform.localPosition = new Vector2(0.7f, 0);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (Move.Pdirection == true && v > 0 && H < 0)
        {
            
            transform.localPosition = new Vector2(0.7f, 0);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

}
