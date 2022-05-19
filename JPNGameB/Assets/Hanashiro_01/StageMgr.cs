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

    private int Pos = 0;
    private float flyPos = 0;

    public GameObject BossEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Barrier.activeSelf == false && isSpawn == false && BossEnemy != null)
        {
            Pos = Random.Range(0, 3);
            switch (Pos)
            {
                case 0:
                    flyPos = 0.50f;
                    break;
                case 1:
                    flyPos = 5.50f;
                    break;
                case 2:
                    flyPos = 10.5f;
                    break;
            }
            fryEne = Instantiate(FryEnemy, new Vector3(flyPos, 3.63f, 0), Quaternion.identity);
            isSpawn = true;
        }

        if(fryEne.activeSelf == false && isStartCol == false)
        {
            StartCoroutine("Spawn");
        }

        if(BossEnemy == null)
        {
            Destroy(fryEne);
        }

    }

    IEnumerator Spawn()
    {
        isBossAttack = true;
        isStartCol = true;
        yield return new WaitForSeconds(3.5f);
        isStartCol = false;
        isSpawn = false;
    }

}
