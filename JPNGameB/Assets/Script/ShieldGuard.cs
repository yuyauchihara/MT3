using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShieldGuard : MonoBehaviour
{
    public bool GuardFlag = false;

    GameObject PlayerAtari;
    PlayerHP playerHp;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if(yuya_Parry.parryf == true) //0328_本来はyuya_Parryだった　
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerAtari = GameObject.Find("PlayerAtari");
        playerHp = PlayerAtari.GetComponent<PlayerHP>();

        if (other.gameObject.tag == "bullet")
        {
            GuardFlag = true;
            playerHp.HealthPoint -= 0.5f;
            Destroy(other.gameObject);
            if (playerHp.HealthPoint == 0)
            {
                Invoke("ChangeScene", 1.5f);
            }
        }
    }
    void ChangeScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}
