using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    private int backP = 0;

    void Start()
    {
        Panel.SetActive(false);
    }
    void Update()
    {

        // スタートボタンを押したらポーズメニューを開く、閉じる
        if (Input.GetKeyDown("joystick button 7") && backP == 0)
        {
            Pause();
            backP++;
        }
        else if (Input.GetKeyDown("joystick button 7") && backP == 1)
        {
            Resume();
            backP--;
        }
    }
    private void Pause()
    {
        Panel.SetActive(true);
    }

    private void Resume()
    {
        Panel.SetActive(false);
    }
}
