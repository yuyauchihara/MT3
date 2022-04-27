using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMuzzle : MonoBehaviour
{
    public GameObject Core1, Core2,Muzzle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Core1.activeSelf == false && Core2.activeSelf == false)
        {
            Muzzle.SetActive(true);
        }
    }
}
