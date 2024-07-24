using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab; // 投げるボールのプレファブ
    public Transform launchPoint; // ボールを投げる位置
    public float StartTimer = 10.0f; // ゲーム開始までの待ち時間（秒）
    public float launchInterval = 7.0f; // ボールを投げる間隔（秒）

    private float timer;

    void Start()
    {
        timer = StartTimer; // タイマーを初期化
    }

    void Update()
    {
        timer -= Time.deltaTime; // タイマーを減らす

        if (timer <= 0 && !ThrowBall.gameover && !ThrowBall.clear)
        {
            LaunchBall(); // ボールを投げる
            timer = launchInterval; // タイマーをリセット
        }

        if ((ThrowBall.gameover || ThrowBall.clear) && timer <= 0)
        {
            SceneManager.LoadScene("Home"); // リザルトシーンに遷移
            ThrowBall.Clear(); // ゲームオーバー時にゲームオーバー状態をリセット
            BallCounter.BallCountClear(); // ゲームオーバー時にボールカウントをリセット
        }
    }

    void LaunchBall()
    {
        if (ballPrefab && launchPoint)
        {
            Instantiate(ballPrefab, launchPoint.position, launchPoint.rotation);
        }
    }
}