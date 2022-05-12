using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    GameObject playerObj;
    //PlayerController player;
    Transform playerTransform;

    public int Camera = 2; 

    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        //player = playerObj.GetComponent<PlayerController>();
        playerTransform = playerObj.transform;
    }

    void LateUpdate()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        //横方向だけ追従
        transform.position = new Vector3(playerTransform.position.x + Camera, transform.position.y, transform.position.z);
    }

}
