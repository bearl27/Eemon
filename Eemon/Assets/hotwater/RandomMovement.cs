using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    // 移動速度
    public float moveSpeed = 5f;

    // ランダムな目標位置
    private Vector3 targetPosition;

    void Start()
    {
        // 初期のランダムな目標位置を設定
        SetRandomTargetPosition();
    }

    void Update()
    {
        // オブジェクトを目標位置に向かって移動
        MoveTowardsTarget();

        // 目標位置に到達したかどうかをチェック
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // 新しいランダムな目標位置を設定
            SetRandomTargetPosition();
        }
    }

    void SetRandomTargetPosition()
    {
        // x: -1 から 1, z: -1 から 1の範囲でランダムな目標位置を設定
        float randomX = Random.Range(-0.4f, 0.4f);
        float randomZ = Random.Range(0.1f, 0.5f);
        targetPosition = new Vector3(randomX, transform.position.y, randomZ);
    }

    void MoveTowardsTarget()
    {
        // 目標位置に向かって徐々に移動
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
