using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cursor : MonoBehaviour
{
    public int Pos = 1;
    public int nummenu;
    public float linewidth;

    public bool MenuMode = false;
    public bool TitleMode = false;
    public bool StageSelectMode = false;
    public bool GameOverMode = false;
    public bool ClearMode = false;
    public bool RetryMode = false;

    private int ModeNum = 0;

    void Start()
    {
        if (MenuMode)
        {
            ModeNum = 1;
        }else if (TitleMode)
        {
            ModeNum = 2;
        }
        else if (StageSelectMode)
        {
            ModeNum = 3;
        }
        else if (GameOverMode)
        {
            ModeNum = 4;
        }
        else if (ClearMode)
        {
            ModeNum = 5;
        }
        else if (RetryMode)
        {
            ModeNum = 6;
        }
    }

    void Update()
    {
        var bathikaru = Input.GetAxis("Vertical");

        if (Input.GetAxisRaw("Vertical") == 1 && Pos != nummenu)
        {
            Vector3 tmp = this.transform.position;
            this.transform.position = new Vector3(tmp.x, tmp.y - linewidth, tmp.z);
            Pos += 1;
        }
        else if (Input.GetAxisRaw("Vertical") == -1 && Pos != 1)
        {
            Vector3 tmp = this.transform.position;
            this.transform.position = new Vector3(tmp.x, tmp.y + linewidth, tmp.z);
            Pos -= 1;
        }
        else if (Input.GetKeyDown("joystick button 0") && Pos != 1)
        {
            switch (ModeNum) {
                default:
                    function();
                    break;
                case 1:
                    MenuFunction();
                    break;
                case 2:
                    TitleFunction();
                    break;
                case 3:
                    StageSelectFunction();
                    break;
                case 4:
                    GameOverFunction();
                    break;
                case 5:
                    ClearFunction();
                    break;
                case 6:
                    RetryFunction();
                    break;
                
            }
        }

    }

    void function()
    {

    }

    void MenuFunction()
    {
        if (Pos == 1)
        {
            // 一番上の項目を選んだときの動作
            // 好きな動作を入れてね
        }
        else if (Pos == 2)
        {

        }
    }

    void TitleFunction()
    {
        if (Pos == 1)
        {
            // 一番上の項目を選んだときの動作
            // 好きな動作を入れてね
        }
        else if (Pos == 2)
        {

        }
    }

    void StageSelectFunction()
    {
        if (Pos == 1)
        {
            // 一番上の項目を選んだときの動作
            // 好きな動作を入れてね
        }
        else if (Pos == 2)
        {

        }
    }

    void GameOverFunction()
    {
        if (Pos == 1)
        {
            // 一番上の項目を選んだときの動作
            // 好きな動作を入れてね
        }
        else if (Pos == 2)
        {

        }
    }

    void ClearFunction()
    {
        if (Pos == 1)
        {
            // 一番上の項目を選んだときの動作
            // 好きな動作を入れてね
        }
        else if (Pos == 2)
        {

        }
    }

    void RetryFunction()
    {
        if (Pos == 1)
        {
            // 一番上の項目を選んだときの動作
            // 好きな動作を入れてね
        }
        else if (Pos == 2)
        {

        }
    }
}