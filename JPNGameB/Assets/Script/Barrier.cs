using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public GameObject Core1, Core2, Core3;
    int BarrierHP = 2;
    bool core1Del = false, core2Del = false, core3Del = false;
    bool ChangeColor = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Core1.activeSelf == false && core1Del == false)
        {
            BarrierHP--;
            core1Del = true;
        }

        if (Core2.activeSelf == false && core2Del == false)
        {
            BarrierHP--;
            core2Del = true;
        }

        if (Core3.activeSelf == false && core3Del == false)
        {
            BarrierHP--;
            core3Del = true;
        }

        if (BarrierHP == 1)
        {
            //GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255,255);
        }

        if(core1Del == true && core2Del == true && core3Del == true)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "bullet")
        {
            Destroy(other.gameObject);
        }
    }

}
