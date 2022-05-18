using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muzzleDel : MonoBehaviour
{
    public GameObject core;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(core.activeSelf == false)
        {
            gameObject.SetActive(false);
        }
    }
}
