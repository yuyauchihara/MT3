using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
public class PlayerDamage : MonoBehaviour
{
    public GameObject hpbar;
    public bool on_damage = false;       //ダメージフラグ
    private SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            
        }
    }
}
