using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmattyaire : MonoBehaviour
{
    public GameObject chawan; // chawanオブジェクトの参照を設定するための変数
    public GameObject chawan1;
    public GameObject chawan2;
    public GameObject chawan3;
    public GameObject chawan4;
    public GameObject GameClear;

    public AudioClip sound1;
    public AudioClip gameclear;
    private AudioSource audioSource; // AudioSource変数を追加

    private Vector3 initialPosition; // 最初のフレームの位置
    private Vector3 previousPosition; // 前のフレームの位置
    private float totalDistance = 0f; // 移動した距離の合計
    private bool clear = false;

    // Start is called before the first frame update
    void Start()
    {
        GameClear.SetActive(false);
        // 最初のフレームの位置を設定
        initialPosition = transform.position;
        previousPosition = initialPosition;

        // chawanタグを持つすべてのオブジェクトを取得
        GameObject[] chawans = GameObject.FindGameObjectsWithTag("chawan");

        foreach (GameObject obj in chawans)
        {
            obj.SetActive(false);
        }
        chawan.SetActive(true);

        // AudioSourceを取得して初期化
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = sound1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;

        // x座標が-1～1かつz座標が-1.5～1.5の間のみ移動距離を加算
        if (currentPosition.x >= -1.1f && currentPosition.x <= -0.85f &&
            currentPosition.z >= 1.2f && currentPosition.z <= 1.5f &&
            currentPosition.y >= -6.5f && currentPosition.y <= -6.3f)
        {
            if (totalDistance == 0)
            {
                audioSource.Play();
            }

            // 前のフレームからの移動距離を計算して合計に加える
            float distanceMoved = Vector3.Distance(currentPosition, previousPosition);
            totalDistance += distanceMoved * 100f;
            print(totalDistance);
            audioSource.UnPause(); // 再開
        }
        else
        {
            audioSource.Pause(); // 停止
        }

        // 前のフレームの位置を更新
        previousPosition = currentPosition;

        // totalDistanceに基づいてオブジェクトの表示/非表示を切り替え
        if (totalDistance >= 0f && totalDistance < 100f)
        {
            chawan.SetActive(true);
        }
        else if (totalDistance >= 100f && totalDistance < 200f)
        {

            chawan.SetActive(false);
            chawan1.SetActive(true);
        }
        else if (totalDistance >= 200f && totalDistance < 300f)
        {
            chawan1.SetActive(false);
            chawan2.SetActive(true);
        }
        else if (totalDistance >= 300f && totalDistance < 400f)
        {
            chawan2.SetActive(false);
            chawan3.SetActive(true);
        }
        else if (totalDistance >= 400f && totalDistance < 500f)
        {
            chawan3.SetActive(false);
            chawan4.SetActive(true);
        }
        else if (totalDistance >= 500f)
        {
            chawan4.SetActive(true);
            GameClear.SetActive(true);
            clear = true;
        }

        if(clear){
            audioSource.clip = gameclear; // ゲームクリア時にクリア音を設定
            audioSource.Play(); // ゲームクリア音を再生
            totalDistance = 0f; // 移動距離をリセット
            clear = false;
            Invoke("gotoHome", 3f); // 5秒後にゲームを終了
        }
    }

    // 最初の一からの移動した値の合計を返す関数
    public float GetTotalDistanceMoved()
    {
        return totalDistance;
    }

    void gotoHome()
    {
        SceneManager.LoadScene("Home");
    }
}
