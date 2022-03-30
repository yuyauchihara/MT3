using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioSource;
    public AudioClip HitSound;
    [SerializeField] GameObject Enemy;
    bool OnePlayerFucker = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Enemy.activeSelf == false)
        {
            if(OnePlayerFucker == false)
            {
                audioSource.PlayOneShot(HitSound);
                OnePlayerFucker = true;
            }           
            Destroy(gameObject, 2);
        }
    }
}
