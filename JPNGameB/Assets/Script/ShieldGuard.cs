using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldGuard : MonoBehaviour
{
    public bool GuardFlag = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(yuya_Parry.parryf == true) //0328_本来はyuya_Parryだった　
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "bullet")
        {
            GuardFlag = true;
            Destroy(other.gameObject);
        }
    }

}
