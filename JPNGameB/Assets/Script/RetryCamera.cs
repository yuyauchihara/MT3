using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RetryCamera : MonoBehaviour
{
    public CinemachineVirtualCamera[] vCamera;

    private int listSize = 0;

    void Start()
    {
        for (int i = 0; i < listSize; i++)
        {
            vCamera[i].Priority = 5;
        }
    }
}
