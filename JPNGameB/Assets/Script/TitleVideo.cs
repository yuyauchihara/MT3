using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TitleVideo : MonoBehaviour
{

    public VideoPlayer videoPlayer;  //アタッチした VideoPlayer をインスペクタでセットする

    // Update is called once per frame
    void Update()
    {
        if ((ulong)videoPlayer.frame == videoPlayer.frameCount)
        {
            //※ここに終了したときの処理など
            return;
        }
    }
}