using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraChange : MonoBehaviour
{
    public CinemachineVirtualCamera vCamera;

    public GameObject BattleWall;

    public static bool Battle = false;

    public bool Boss = false;
    public GameObject BossEnemy;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!Boss)
        {
            if (other.tag == "Player" && Battle)
            {
                vCamera.Priority = 100;
            }

            if (other.tag == "Player" && !Battle)
            {
                vCamera.Priority = 5;
            }
        }
        else if (Boss){
            if (other.tag == "Player" /*&& Battle*/ && BossEnemy != null)
            {
                //Debug.Log(BossEnemy);
                vCamera.Priority = 100;
            }

            if (other.tag == "Player" && BossEnemy == null)
            {
                //Debug.Log(BossEnemy);
                vCamera.Priority = 5;
            }
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
