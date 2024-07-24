using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    public float throwForce = 1000f;  // 投げる力の大きさ
    public float additionalYForce = 300f;  // Y方向に追加する力の大きさ

    private Rigidbody rb;  // Rigidbodyのキャッシュ

    public static bool clear = false;   // クリア状態かどうか
    public static bool gameover = false; // ゲームオーバー状態かどうか
    public static int ballCount = 0;

    public AudioClip hitting; // 再生する音源を設定
    public AudioClip catching; // 再生する音源を設定
    public AudioClip outSound; // 再生する音源を設定

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Rigidbodyコンポーネントを取得してキャッシュ
        rb.AddForce(transform.forward * throwForce);  // ボールに前方向へ力を加える
    }

    void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトのタグが"Bat"の場合、方向を逆転しつつY方向の力を追加
        if (collision.gameObject.tag == "Bat")
        {
            rb.velocity = Vector3.zero;  // 現在の速度をリセット

            // 後ろ方向に力を加え，Y方向に追加の力を加える
            Vector3 reflectedForce = -transform.forward * throwForce + Vector3.up * additionalYForce;
            rb.AddForce(reflectedForce.normalized * throwForce);
            // 指定した音源を再生
            AudioSource.PlayClipAtPoint(hitting, collision.GetContact(0).point);
            clear = true;
        }

        if (!clear && collision.gameObject.tag == "Ground")
        {
            ballCount++;
            AudioSource.PlayClipAtPoint(catching, collision.GetContact(0).point);
            if (ballCount == 3)
            {
                gameover = true;
                AudioSource.PlayClipAtPoint(outSound, collision.GetContact(0).point);
            }
            gameObject.SetActive(false);
        }
    }

    public static void Clear()
    {
        ballCount = 0;
        gameover = false;
        clear = false;
    }

}