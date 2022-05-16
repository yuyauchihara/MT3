using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;//追加
using UnityEngine.SceneManagement;//追加

public class fadeoutScene : MonoBehaviour
{
    public GameObject fade;//インスペクタからPrefab化したCanvasを入れる
    public GameObject fadeCanvas;//操作するCanvas、タグで探す

    public SceneChange sceneChange;

    void Start()
    {
        if (!FadeManager.isFadeInstance)//isFadeInstanceは後で用意する
        {
            Instantiate(fade);
            Invoke("findFadeObject", 0.2f);//起動時用にCanvasの召喚をちょっと待つ
        }else if (FadeManager.isFadeInstance)
        {
            Invoke("findFadeObject", 0.0f);
        }
    }

    void findFadeObject()
    {
        fadeCanvas = GameObject.FindGameObjectWithTag("Fade");//Canvasをみつける
        fadeCanvas.GetComponent<FadeManager>().fadeIn();//フェードインフラグを立てる

        Debug.Log("Name:" + fadeCanvas.name);
    }

    public async void fadeSceneChange()//ボタン操作などで呼び出す
    {
        fadeCanvas.GetComponent<FadeManager>().fadeOut();//フェードアウトフラグを立てる
        await Task.Delay(200);//暗転するまで待つ
        sceneChange.Change();
        //SceneManager.LoadScene("1-2");//シーンチェンジ
    }
}
