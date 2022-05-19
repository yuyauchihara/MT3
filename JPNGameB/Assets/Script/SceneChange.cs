using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public int Scene = 0;
    public int RetrySceneNum = 0;
    public static string SceneName;
    public string[] StageName;
    private string[] SceneChangeName;

    public bool StageMode = false;      //ステージを変える方(trueならステージ切り替えモード)
    public bool SceneMode = true;       //シーンを変える方(trueならシーン切り替えモード)※初期true

    public fadeoutScene fadeout;        //フェードアウトするオブジェクト格納

    public bool FadeOutInMode = true;   //フェードインさせるかどうかのフラグtrueならさせる

    public bool title = false;          //タイトルならtrueにしとく

    public bool RetryMode = false;          //リトライシーンではtrueにする

    public string NowScene;

    public static int Nownum = 0;

    public bool TitleBack = false;

    void Start()
    {
        StageName = new string[] { "1-1", "1-2", "1-3", "2-1", "2-2", "2-3", "3-1", "3-2", "3-3" };     //ステージを切り替えるための変数   StageModeがtrueの時
        SceneChangeName = new string[] { "title", "StageSelect", "clear" };                     //シーンを切り替えるための変数 SceneModeがtrueの時

        NowScene = StageName[Nownum];
    }

    void Update()
    {
        //if (Input.GetKey("joystick button 1"))
        //{
        //    Scene = 3;
        //}
        //else if (Input.GetKey("joystick button 3"))
        //{
        //    Scene = 6;
        //}

        if (SceneMode)           //モードの切り替えでtrueになったらもう片方をfalseにする
        {
            StageMode = false;
        }
        else if(!SceneMode)
        {
            StageMode = true;
        }

        if (StageMode)          //モードの切り替えでtrueになったらもう片方をfalseにする
        {
            SceneMode = false;
        }
        else if(!StageMode)
        {
            SceneMode = true;
        }
        //if (title)
        //{
        //    if (Input.GetKey("joystick button 0") || Input.GetKey("joystick button 1") || Input.GetKey("joystick button 3"))
        //    {
        //        if (SceneMode)
        //        {
        //            SceneName = SceneChangeName[Scene];
        //            Change();
        //        }

        //        if (StageMode)
        //        {
        //            SceneName = StageName[Scene];
        //            Change();
        //        }
        //    }
        //}

        //if (RetryMode)
        //{
        //    //リトライ
        //    if (Input.GetKey("joystick button 0"))
        //    {
        //        RetryScene();
        //    }
        //    //ゲーム終了
        //    if (Input.GetKey("joystick button 1"))
        //    {
        //        GameEnd();
        //    }
        //}

        if(Input.GetKey("joystick button 1") && TitleBack)
        {
            SceneManager.LoadScene("Title");
        }

    }

    public void ChangeStage()
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

    public void ChangeScene()
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

    public void GameEnd()
    {
        Application.Quit();
    }

    public void Change()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void RetryScene()
    {
        SceneManager.LoadScene(NowScene);
    }
}
