using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayHitSound : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip HitSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //audioSource.PlayOneShot(HitSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            //if (bullet.FriendlyFireFlag == true)
            //{
                audioSource.PlayOneShot(HitSound);
            //}
        }

        if (other.gameObject.tag == "HightPower")
        {
            //if (bullet.FriendlyFireFlag == true)
            //{
                audioSource.PlayOneShot(HitSound);
            //}
        }
    }

}
