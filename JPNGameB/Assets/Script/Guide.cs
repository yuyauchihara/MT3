using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{
    public SpriteRenderer sp;
    // ダメージ判定フラグ


    void Start()
    {
        
    }

    void Update()
    {
        var h = Input.GetAxis("Horizontal");//左スティックの横

        if (Input.GetKey("joystick button 5"))
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 2));
            sp.color = new Color(1f, 1f, 1f, level);
        }
        else
        {
            sp.color = new Color(1f, 1f, 1f, 1f);
        }

        if (h < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            //transform.localPosition = new Vector2(-1.8f, 0);

        }
        else if (0 < h)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            //transform.localPosition = new Vector2(1.8f, 0);
        }
    }

}
