using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    private void Start()
    {

    }

    void Update()
    {
        Invoke("GameOverChangeScene", 3.0f);
    }

    void GameOverChangeScene()
    {
        SceneManager.LoadScene("retry");
    }
}