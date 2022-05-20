using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ChangeScene", 5.6f);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("StageSelect");
    }
}
