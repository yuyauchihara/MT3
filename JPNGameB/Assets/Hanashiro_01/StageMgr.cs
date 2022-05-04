using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMgr : MonoBehaviour
{
    public GameObject Barrier;
    public GameObject FryEnemy;
    bool isSpawn = false , isStartCol = false;
    public static bool isBossAttack = false;
    GameObject fryEne;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Barrier.activeSelf == false && isSpawn == false)
        {
            fryEne = Instantiate(FryEnemy, transform.position, Quaternion.identity);
            isSpawn = true;
        }

        if(fryEne.activeSelf == false && isStartCol == false)
        {
            StartCoroutine("Spawn");
        }

    }

    IEnumerator Spawn()
    {
        isBossAttack = true;
        isStartCol = true;
        yield return new WaitForSeconds(5.5f);
        isStartCol = false;
        isSpawn = false;
    }

}
