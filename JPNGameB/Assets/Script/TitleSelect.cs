using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleSelect : MonoBehaviour
{

    public RectTransform a;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        a.position += new Vector3(0.1f, 0, 0);
    }
    void OnEnable()
    {
        

    }
}
