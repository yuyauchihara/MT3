using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraChange : MonoBehaviour
{
    public CinemachineVirtualCamera vCamera;

    public GameObject BattleWall;

    public static bool Battle = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player" && Battle)
        {
            vCamera.Priority = 100;
        }

        if(other.tag == "Player" && !Battle)
        {
            vCamera.Priority = 5;
        }

        if (Battle == true)
        {
            BattleWall.gameObject.SetActive(true);
        }
        else
        {
            BattleWall.gameObject.SetActive(false);
        }
    }
}
