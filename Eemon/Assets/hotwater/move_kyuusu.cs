using UnityEngine;

public class KyuusuMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 移動速度を調整するための変数

    void Update()
    {
        // Z軸方向の移動
        if (Input.GetKey("w"))
        {
            transform.Translate(0f, 0f, moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey("s"))
        {
            transform.Translate(0f, 0f, -moveSpeed * Time.deltaTime);
        }

        // X軸方向の移動
        if (Input.GetKey("d"))
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0f, 0f);
        }
        else if (Input.GetKey("a"))
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0f, 0f);
        }
    }
}
