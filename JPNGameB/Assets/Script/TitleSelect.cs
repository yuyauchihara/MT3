using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleSelect : MonoBehaviour
{

    public RectTransform a;
    public GameObject SelectIcon;
    public int SelectIconPosition;

    bool nowExecCoroutine_ = false;

    // Start is called before the first frame update
    void Start()
    {
        SelectIconPosition = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!nowExecCoroutine_)
        {
            nowExecCoroutine_ = true;
            StartCoroutine(SelectIconMove());
        }
    }

    IEnumerator SelectIconMove()
    {

        if (Input.GetAxisRaw("Vertical2") == 1)
        {
            a.position += new Vector3(5f, 0, 0);
        }
        else if (Input.GetAxisRaw("Vertical2") == -1)
        {
            a.position -= new Vector3(5f, 0, 0);
        }

        yield return new WaitForSeconds(0.25f);

        nowExecCoroutine_ = false;
    }
}
