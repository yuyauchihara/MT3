using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMGR : MonoBehaviour
{
    [SerializeField] private GameObject Img;
    [SerializeField] private GameObject Canvas;

    private bool ImgFLG = false;

    private bool CanvasFLG = false;

    private int FlgTimer = 0;

    private int CanvasTimer = 0;

    void Start()
    {
        Img.SetActive(false);
        Canvas.SetActive(false);
    }

    void FixedUpdate()
    {
        if(FlgTimer < 330)
        {
            ImgFLG = false;
        }else if(FlgTimer >= 330)
        {
            ImgFLG = true;
        }

        if (!ImgFLG)
        {
            if (FlgTimer < 340)
            {
                FlgTimer++;
            }
        }else if (ImgFLG)
        {
            if (!CanvasFLG)
            {
                Img.SetActive(true);
            }
            if(Input.GetKey("joystick button 0") || Input.GetKey("joystick button 1") || Input.GetKey("joystick button 2") || Input.GetKey("joystick button 3"))
            {
                Img.SetActive(false);
                CanvasFLG = true;
            }
        }

        if (CanvasFLG)
        {
            if (CanvasTimer < 30)
            {
                CanvasTimer++;
            }
            if(CanvasTimer > 20)
            {
                Canvas.SetActive(true);
            }
        }
    }
}
