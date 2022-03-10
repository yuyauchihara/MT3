using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject Spawn;

    void Start()
    {
        Spawn.gameObject.SetActive(false);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Spawn.gameObject.SetActive(true);
        }
    }
}
