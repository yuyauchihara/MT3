using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    [SerializeField] private GameObject cursorImg;
    private int backP = 0;

    GameObject Object;
    Cursor cursor;

    void Start()
    {
        Object = GameObject.Find("Cursor");
        cursor = Object.GetComponent<Cursor>();
        Panel.SetActive(false);
        cursorImg.SetActive(false);
    }
    void Update()
    {

        // スタートボタンを押したらポーズメニューを開く、閉じる
        if (Input.GetKeyDown("joystick button 7") && backP == 0)
        {
            Pause();
            backP++;
            Vector3 tmp = Object.transform.position;
            Object.transform.position = new Vector3(tmp.x, 511.1f, tmp.z);
            cursor.Pos = 1;
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
        cursorImg.SetActive(true);
    }

    private void Resume()
    {
        Panel.SetActive(false);
        cursorImg.SetActive(false);
    }
}
