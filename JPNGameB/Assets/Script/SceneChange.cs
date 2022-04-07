using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    void Start()
    {
        Invoke("ChangeScene", 2.0f);
    }

    void Update()
    {
        
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("1-1");
    }
}
