using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deer : MonoBehaviour {
    public float destroyTime = 1.0f;
    GameObject player;
    public float gameoverTime = 1.0f;
    public bool CanWalk;
    public static bool isGameClear = false; // ゲームクリアフラグ
    public static bool isGameOver = false; // ゲームオーバーフラグ
    public float rangeDistance = 10.0f; // プレイヤーとの距離

    // Use this for initialization
    void Start () {

        player = GameObject.FindWithTag("Player");

        CanWalk = true;

	}

	// Update is called once per frame
	void Update () {

        // プレイヤーの位置
        var playerPosition = player.transform.position;

        // ゾンビの位置
        var DeerPosition = transform.position;

        // ゾンビとプレイヤーがどれだけ離れているか
        var offset = Mathf.Abs(Vector3.Distance(playerPosition, DeerPosition));
        // プレイヤーとゾンビの距離が近くなったら攻撃
        if (offset < rangeDistance && !isGameOver)
        {
            // ゲームオーバー
            isGameOver = true;

            CanWalk = false;

            // 1秒後にGameOverSceneに遷移
            Invoke("GameOver", gameoverTime);
        }

    }

    void GameOver()
    {
        isGameOver = false;
        Debug.Log("GameOver");
        SceneManager.LoadScene("GameOver");
    }
}