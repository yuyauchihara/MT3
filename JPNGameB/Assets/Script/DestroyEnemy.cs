using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioSource;
    public AudioClip HitSound;
    [SerializeField] GameObject Enemy;
    bool OnePlay = false;

    public bool BossEnemy = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Enemy.activeSelf == false)
        {
            if(OnePlay == false)
            {
                audioSource.PlayOneShot(HitSound);
                OnePlay = true;
            }
            StartCoroutine("AcFal");
        }
    }

    IEnumerator AcFal()
    {
        yield return new WaitForSeconds(1.0f);
        if (!BossEnemy)
        {
            gameObject.SetActive(false);
        }else if (BossEnemy)
        {
            Destroy(gameObject);
        }
    }

}
