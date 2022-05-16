using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMuzzle : MonoBehaviour
{
    public GameObject Barrier,Muzzle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Barrier.activeSelf == false)
        {
            Muzzle.SetActive(true);
        }
    }
}
