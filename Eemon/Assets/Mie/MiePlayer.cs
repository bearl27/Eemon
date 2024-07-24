using UnityEngine;

public class MiePlayer : MonoBehaviour
{
    public float moveSpeed = 2.0f;

    void Update()
    {
        // キーボードの入力を取得
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        // 入力に合わせて移動方向を設定
        Vector3 moveDirection = new Vector3(moveHorizontal, moveVertical,0);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}