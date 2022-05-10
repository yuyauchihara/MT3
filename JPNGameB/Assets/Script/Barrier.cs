using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public GameObject[] Core;
    int Yososu = 0;
    int BarrierHP = 2;
    bool core1Del = false, core2Del = false, core3Del = false;
    bool ChangeColor = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Yososu = Core.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Core[0].activeSelf == false && Core[1].activeSelf == false && Core[2].activeSelf == false)
        {
            gameObject.SetActive(false);
        }

        if (BarrierHP == 1)
        {
            //GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255,255);
        }

        //if(Core[0].SetActive == false && Core[1].SetActive == false)
        //{
        //    gameObject.SetActive(false);
        //}



    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "bullet")
        {
            Destroy(other.gameObject);
        }
    }

}
