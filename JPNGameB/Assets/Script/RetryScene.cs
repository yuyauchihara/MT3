using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //リトライ
        if(Input.GetKey("joystick button 0"))
        {
            Invoke("RetryChangeScene", 1.0f);
        }
        //ゲーム終了
        if(Input.GetKey("joystick button 1"))
        {
            Invoke("GameEnd", 1.0f);
        }
    }

    void RetryChangeScene()
    {
        SceneManager.LoadScene("yuya2");
    }

    void GameEnd()
    {
        Application.Quit();
    }
}
