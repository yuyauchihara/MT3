using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public int Scene = 0;
    public static string SceneName;
    private string[] StageName;
    private string[] SceneChangeName;

    public bool StageMode = false;      //ステージを変える方(trueならステージ切り替えモード)
    public bool SceneMode = true;       //シーンを変える方(trueならシーン切り替えモード)※初期true

    public fadeoutScene fadeout;        //フェードアウトするオブジェクト格納

    public bool FadeOutInMode = true;   //フェードインさせるかどうかのフラグtrueならさせる

    public bool title = false;          //タイトルならtrueにしとく

    void Start()
    {
        StageName = new string[] { "1-1", "1-2", "1-3", "2-1", "2-2", "2-3", "3-1", "3-2", "3-3" };     //ステージを切り替えるための変数
        SceneChangeName = new string[] { "title", "StageSlect", "clear" };                     //シーンを切り替えるための変数
    }

    void Update()
    {
        if (SceneMode)           //モードの切り替えでtrueになったらもう片方をfalseにする
        {
            StageMode = false;
        }
        else
        {
            StageMode = true;
        }

        if (StageMode)          //モードの切り替えでtrueになったらもう片方をfalseにする
        {
            SceneMode = false;
        }
        else
        {
            SceneMode = true;
        }

        if(Input.GetKey("joystick button 0") && title || Input.GetKey("joystick button 1") && title || Input.GetKey("joystick button 3") && title)
        {
            if (SceneMode)
            {
                SceneName = SceneChangeName[Scene];
                Change();
            }

            if (StageMode)
            {
                SceneName = StageName[Scene];
                Change();
            }
        }

    }

    void ChangeStage()
    {
        SceneName = StageName[Scene];
        if (FadeOutInMode)
        {
            fadeout.fadeSceneChange();
        }
        else if (!FadeOutInMode)
        {
            Change();
        }
    }

    void ChangeScene()
    {
        if (Scene < 3)                                  //格納している変数の値を超えていない
        {
            SceneName = SceneChangeName[Scene];
            if (FadeOutInMode)
            {
                fadeout.fadeSceneChange();
            }else if (!FadeOutInMode)
            {
                Change();
            }
        }
        else                                            //超えていたらゲームを終了する
        {
            GameEnd();
        }
    }

    public void goalKenti()
    {

        if (ChangeSceneFLG.ClearFlag && SceneMode)
        {
            Invoke("ChangeScene", 0.0f);
        }

        if (ChangeSceneFLG.ClearFlag && StageMode)
        {
            Invoke("ChangeStage", 0.0f);
        }
    }

    void clear()
    {

    }

    void GameEnd()
    {
        Application.Quit();
    }

    public void Change()
    {
        SceneManager.LoadScene(SceneName);
    }
}
