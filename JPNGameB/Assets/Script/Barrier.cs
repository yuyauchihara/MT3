using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public GameObject Core1, Core2;
    int BarrierHP = 2;
    bool core1Del = false, core2Del = false;
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

        if(BarrierHP == 1)
        {
            GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255,255);
        }

        if(BarrierHP <= 0)
        {
            Destroy(gameObject);
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
