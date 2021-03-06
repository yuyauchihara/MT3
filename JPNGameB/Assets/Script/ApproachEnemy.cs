using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApproachEnemy : MonoBehaviour
{
    public GameObject player;
    public GameObject paneru;
    public GameObject knocktim;
    public GameObject sec;
    public bool counterFlag = false;

    Text seco;
    Move move;
    bool moveKnock;
    public float moveSpeed;
    bool Dflag = false; //エネミーが岩に当たったら死ぬ
    int WaitToAttack = 3;

    // Start is called before the first frame update
    void Start()
    {
        move = player.GetComponent<Move>();
        seco = sec.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        seco.text = WaitToAttack.ToString();

        if (moveKnock == true)
        {
            //Debug.Log("true");
        }
        else
        {
            //Debug.Log("false");
        }

        moveKnock = move.KnockFlag;
        if (moveKnock == false)
        {
            transform.Translate(moveSpeed, 0, 0); // 移動
        }
        else
        {
            if (moveKnock == true && move.i == 0)
            {
                StartCoroutine("KnockBack");
            }
        }

        if (WaitToAttack <= 0)
        {
            //paneru.SetActive(true);
        }

        if (WaitToAttack == 1)
        {
            counterFlag = true;
            GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        }
        else
        {
            counterFlag = false;
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 0);
        }

    }

    IEnumerator KnockBack()
    {
        //transform.Translate(3.03f, 0, 0);
        //yield return new WaitForSeconds(0.1f);
        //transform.Translate(1f, 0, 0);
        GetComponent<Rigidbody2D>().velocity = new Vector2(6, 0);
        Dflag = true;
        yield return new WaitForSeconds(1f);
        Dflag = false;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Rock" && Dflag == true)
        {
            Debug.Log("やーらーれーたー");
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player")
        {
            moveSpeed = 0;
            StartCoroutine("Attack");
        }

        if (other.gameObject.tag == "bullet")
        {
            if(move.KillAprEnmyFlg == true)
            {
                Destroy(gameObject);
            }
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            moveSpeed = -0.03f;
            StopCoroutine("Attack");
            WaitToAttack = 3;
        }
    }

    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            WaitToAttack--;
        }
    }
}
