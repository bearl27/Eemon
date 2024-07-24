using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneToHome : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 5秒後にgoHomeメソッドを呼び出す
        Invoke("goHome", 5.0f);
    }

    void goHome()
    {
        // シーンをHomeに遷移
        SceneManager.LoadScene("Home");
    }
}
