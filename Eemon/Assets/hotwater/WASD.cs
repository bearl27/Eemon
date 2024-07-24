using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // プレイヤーの移動速度

    // Update is called once per frame
    void Update()
    {
        // WASDキーの入力を取得
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 入力に基づいて移動方向を計算
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // プレイヤーを移動する
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
