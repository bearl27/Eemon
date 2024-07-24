using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {
    public int gamePoint;

    public GameObject score_object; // スコア
    public GameObject explain_object; // 説明

      // 初期化
    void Start () {
        int random = Random.Range(6, 15);
        gamePoint = random * 10;
    }

      // 更新
    void Update () {
        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text> ();
        // テキストの表示を入れ替える
        score_text.text = "Points : " + gamePoint.ToString();
        if(gamePoint < 0)
        {
            explain_object.SetActive(false);
            score_text.text = "BUST...";
            Invoke("gotoHome", 2.0f);
        }
        else if(gamePoint == 0){
            explain_object.SetActive(false);
            score_text.text = "CLEAR!!";
            Invoke("gotoHome", 2.0f);
        }
        if(gamePoint > 0 && ShurikenMovementSetup.throwCount == 3 && !ShurikenMovementSetup.isThrowing){
            score_text.text = "Game Over...";
            explain_object.SetActive(false);
            ShurikenMovementSetup.throwCount = 0;
            Invoke("gotoHome", 2.0f);
        }
    }
    void gotoHome(){
        SceneManager.LoadScene("Home");
    }
}