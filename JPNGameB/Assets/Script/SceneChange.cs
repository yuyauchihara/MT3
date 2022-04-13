using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public int Scene = 0;
    public static string SceneName;
    private string[] ScenesName;
    public GameObject FOB;

    void Start()
    {
        ScenesName = new string[] { "clear", "1-1", "1-2", "1-3" };
    }

    void ChangeScene()
    {
        //switch (Scene)
        //{
        //    default:
        //        SceneManager.LoadScene("title");
        //        break;

        //    case 0:
        //        SceneManager.LoadScene("clear");
        //        break;

        //    case 1:
        //        SceneManager.LoadScene("1-1");
        //        break;

        //    case 2:
        //        SceneManager.LoadScene("1-2");
        //        break;

        //    case 3:
        //        SceneManager.LoadScene("1-3");
        //        break;
        //}
        SceneName = ScenesName[Scene];
        FOB.GetComponent<fadeoutScene>().sceneChange();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "goal" && GateOpen.ClearFlag)
        {
            Invoke("ChangeScene", 0.0f);
        }
    }
}
