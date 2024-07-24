using UnityEngine;

public class RandomMovementManager : MonoBehaviour
{
    public GameObject chawan0; // chawan0オブジェクトの参照を設定するための変数
    public GameObject chawan1; // chawan1オブジェクトの参照を設定するための変数
    public GameObject chawan2; // chawan2オブジェクトの参照を設定するための変数
    public GameObject chawan3; // chawan3オブジェクトの参照を設定するための変数
    public GameObject chawan4; // chawan4オブジェクトの参照を設定するための変数
    public GameObject chawan5; // chawan5オブジェクトの参照を設定するための変数

    public float moveSpeed = 5f; // 移動速度を調整するための変数
    public float changeDirectionInterval = 2f; // 移動方向を変更する間隔
    public Vector3 minBounds; // 移動範囲の最小値
    public Vector3 maxBounds; // 移動範囲の最大値

    private float timer; // 移動方向を変更するタイマー
    private Vector3 moveDirection; // 現在の移動方向

    void Start()
    {
        // 最初の移動方向をランダムに設定する
        ChangeDirection();
        timer = changeDirectionInterval; // 初期化
    }

    void Update()
    {
        // タイマーを更新する
        timer -= Time.deltaTime;

        // タイマーが0以下になったら新しい移動方向を設定する
        if (timer <= 0f)
        {
            ChangeDirection();
            timer = changeDirectionInterval;
        }

        // 現在の方向に速度をかけて移動する
        MoveObjects();
    }

    void ChangeDirection()
    {
        // ランダムな方向ベクトルを生成する
        moveDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
    }

    void MoveObjects()
    {
        // 各オブジェクトを移動させる
        if (chawan0 != null) MoveObjectWithinBounds(chawan0);
        if (chawan1 != null) MoveObjectWithinBounds(chawan1);
        if (chawan2 != null) MoveObjectWithinBounds(chawan2);
        if (chawan3 != null) MoveObjectWithinBounds(chawan3);
        if (chawan4 != null) MoveObjectWithinBounds(chawan4);
        if (chawan5 != null) MoveObjectWithinBounds(chawan5);
    }

    void MoveObjectWithinBounds(GameObject obj)
    {
        Vector3 newPosition = obj.transform.position + moveDirection * moveSpeed * Time.deltaTime;

        // 移動先が指定した範囲内かどうか確認する
        if (newPosition.x >= minBounds.x && newPosition.x <= maxBounds.x &&
            newPosition.z >= minBounds.z && newPosition.z <= maxBounds.z)
        {
            // 範囲内なら移動を適用する
            obj.transform.position = newPosition;
        }
        else
        {
            // 範囲外なら逆方向に移動方向を変更する
            ChangeDirection();
        }
    }
}
