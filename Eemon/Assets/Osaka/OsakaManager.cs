using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class OsakaManager : MonoBehaviour
{
    public float qlearTime = 30.0f;
    public GameObject tako;
    public Vector3 takoPosition = new Vector3((float)0.9, (float)0.8, 0);
    public TextMeshPro score;
    private bool isThrowing = false;

    public static int takoCount = 0;
    void Start()
    {
        // 30秒後にGameQlearSceneに遷移
        //Invoke("GameClear", qlearTime);
    }

    void Update()
    {
        if(TakoManager.gameOver)
        {
            //SceneManager.LoadScene("GameOver");
            takoCount--;
            if(takoCount < 0)
            {
                takoCount = 0;
            }
            Invoke("gotoHome", 3.0f);
            TakoManager.gameOver = false;
        }
        score.text = takoCount.ToString();
        if(!TakoManager.gameOver && TakoManager.canInstantiate)
        {
            Instantiate(tako, takoPosition, Quaternion.identity);
            TakoManager.canInstantiate = false;
            takoCount++;
        }
    }

    void GameClear()
    {
        Debug.Log("GameClear");
        //SceneManager.LoadScene("GameQlear");
    }

    void gotoHome()
    {
        SceneManager.LoadScene("Home");
        takoCount = 0;
    }
}
