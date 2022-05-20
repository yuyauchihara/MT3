using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    //[SerializeField] private GameObject cursorImg;
    private int backP = 0;

    public RectTransform cursorPos;

    GameObject Object;
    Cursor cursor;

    void Start()
    {
        Object = GameObject.Find("Cursor");
        cursor = Object.GetComponent<Cursor>();
        Panel.SetActive(false);
    }

    void Update()
    {

        // スタートボタンを押したらポーズメニューを開く、閉じる
        if (Input.GetKeyDown("joystick button 7") && backP == 0)
        {
            Pause();
            backP++;
            Vector3 tmp = cursorPos.position;
            cursorPos.position = new Vector3(tmp.x, 510.625f, tmp.z);
            cursor.Pos = 1;
            //cursor.Text1.fontSize = 61;
            //cursor.Text2.fontSize = 51;
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown("joystick button 7") && backP == 1)
        {
            Resume();
            backP--;
            Time.timeScale = 1;
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
