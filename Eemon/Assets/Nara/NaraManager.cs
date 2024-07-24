using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NaraManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float qlearTime = 30.0f;
    void Start()
    {
        // 30秒後にGameQlearSceneに遷移
        Invoke("GameQlear", qlearTime);
    }

    void GameQlear()
    {
        Debug.Log("GameQlear");
        SceneManager.LoadScene("GameQlear");
    }
}
