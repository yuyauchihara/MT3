using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public Slider Tairyoku;
    float HealthPoint = 10.0f;
    float MaxHP = 10.0f;

    public static bool HoldShield = false;

    // Start is called before the first frame update
    void Start()
    {
        
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

        if (other.gameObject.tag == "bullet" && !PlayerDamage.isDamage)
        {
           
<<<<<<< HEAD
            if (yuya_Parry.parryf == false)
=======
            if (Shoei_Parry.parryf == false)
>>>>>>> ed8b750e5186f2c8e8ed1874f38181d1355b7aeb
            {
                HealthPoint--;
                Destroy(other.gameObject);
            }
            
        }

        
    }
}
