using UnityEngine;
using UnityEngine.SceneManagement;

public class Fishing : MonoBehaviour
{
    private GameObject collidingObject;  // 衝突中のオブジェクトを保存する変数
    public static bool isFishing = false; //釣れたかどうか

    public AudioClip FishSound;  // 音声ファイルを格納する変数
    public AudioClip ReelSound;  // 音声ファイルを格納する変数
    private bool gameclear = false;  // ゲームクリアフラグ
    private bool gameover = false;  // ゲームオーバーフラグ

    float timer = 0;  // タイマー変数

    float gameOverTime = 60;  // ゲームオーバー時間

    public GameObject Fish;  // 魚のプレハブを格納する変数
    static public int reelCount = 0;  // 釣り上げた魚の数

    float reelTime = 3.0f;  // リール時間


    void Update()
    {
        timer += Time.deltaTime;  // タイマーを更新
        reelTime -= Time.deltaTime;  // リール時間を更新
        // エンターキーが押されたかを監視し、衝突中のオブジェクトがあれば非アクティブにする
        if ( reelTime <= 0 && (Input.GetKeyDown(KeyCode.Return) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) && collidingObject != null)
        {
            AudioSource.PlayClipAtPoint(ReelSound, transform.position);  // 音声を再生
            reelCount++;  // 釣り上げた数をカウント
            reelTime = 3.0f;  // リール時間をリセット
        }
        if (!isFishing && reelCount == 3){
            AudioSource.PlayClipAtPoint(FishSound, transform.position);  // 音声を再生
            isFishing = true;  // 釣れたフラグを立てる
            Debug.Log("釣れた！");  // デバッグログを出力
        }

        // オブジェクトが一定の高さ以上になったら破棄
        if(gameObject.transform.position.y > 2.0f)
        {
            Destroy(gameObject);
            gameObject.transform.position = new Vector3(0, 0, 0);
            gameclear = true;
        }

        // タイマーが10秒を超えたらゲームオーバー
        if(!gameclear && timer > gameOverTime)
        {
            gameover = true;
        }

        if(gameclear)
        {
            Debug.Log("GameClear");
            gameclear = false;
            isFishing = false;
            reelCount = 0;
            Instantiate(Fish, new Vector3(0, 0, 0), Quaternion.identity);
            SceneManager.LoadScene("GameQlear");
        }

        if(gameover)
        {
            Debug.Log("GameOver");
            gameover = false;
            isFishing = false;
            reelCount = 0;
            SceneManager.LoadScene("GameOver");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // 衝突したオブジェクトが「Ito」タグを持っているか確認
        if (other.CompareTag("Ito"))
        {
            collidingObject = other.gameObject;  // 衝突オブジェクトを記録
        }
    }

    void OnTriggerExit(Collider other)
    {
        // 衝突が終了した場合、記録していたオブジェクトをクリア
        if (other.gameObject == collidingObject)
        {
            collidingObject = null;
        }
    }
}