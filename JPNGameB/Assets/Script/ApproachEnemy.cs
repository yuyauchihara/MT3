using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachEnemy : MonoBehaviour
{
    public GameObject player;
    Move move;
    bool moveKnock;
    // Start is called before the first frame update
    void Start()
    {
        move = player.GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        moveKnock = move.KnockFlag;
        if(moveKnock == false)
        {
            transform.Translate(-0.05f, 0, 0);
        }
        else
        {
            if(moveKnock == true)
            {
                transform.Translate(0.1f, 0, 0);
                moveKnock = false;
            }
        }
    }
}
