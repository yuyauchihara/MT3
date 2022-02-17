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
        if(moveKnock == true)
        {
            Debug.Log("true");
        }
        else
        {
            Debug.Log("false");
        }

        moveKnock = move.KnockFlag;
        if(moveKnock == false)
        {
            transform.Translate(-0.05f, 0, 0);
        }
        else
        {
            if (moveKnock == true && move.i == 0)
            {
                StartCoroutine("KnockBack");
            }
        }
    }

    IEnumerator KnockBack()
    {
        transform.Translate(0.03f, 0, 0);
        yield return new WaitForSeconds(0.01f);
        
        moveKnock = false;
    }
}
