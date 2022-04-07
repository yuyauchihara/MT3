using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraChange : MonoBehaviour
{
    public CinemachineVirtualCamera vCamera;

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
    }
}
