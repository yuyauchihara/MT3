using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "goal" && GateOpen.ClearFlag)
        {
            Invoke("ChangeScene", 0.0f);
        }
    }
    void ChangeScene()
    {
        SceneManager.LoadScene("clear");
    }
}
