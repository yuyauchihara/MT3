using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHOJI : MonoBehaviour
{
    GameObject Object;
    SceneChange Now;

    void Start()
    {
        Object = GameObject.Find("SceneChangeObject");
        Now = Object.GetComponent<SceneChange>();
        SceneChange.Nownum = Now.RetrySceneNum;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
