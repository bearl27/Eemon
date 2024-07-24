using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public OVRCameraRig ovrCameraRig;
    public float moveSpeed = 2.0f;
    public float minDistance = 0.1f;  // 衝突の最小距離

    private Transform centerEyeAnchor;

    void Start()
    {
        if (ovrCameraRig == null)
        {
            Debug.LogError("OVRCameraRigが設定されていません。");
            return;
        }

        // CenterEyeAnchorの参照を取得
        centerEyeAnchor = ovrCameraRig.centerEyeAnchor;
    }

    void Update()
    {
        if (centerEyeAnchor == null)
            return;

        // キーボードの入力を取得
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        // CenterEyeAnchorのY軸の回転を基に移動ベクトルを計算
        Vector3 forward = centerEyeAnchor.forward;
        Vector3 right = centerEyeAnchor.right;

        // forwardとrightのY軸回転成分のみを抽出
        forward.y = 0;
        right.y = 0;

        // 正規化して方向ベクトルを計算
        forward.Normalize();
        right.Normalize();

        // 移動方向を計算
        Vector3 moveDirection = (forward * moveVertical + right * moveHorizontal).normalized;

        // 移動ベクトルに速度と時間を掛けて移動量を計算
        Vector3 moveAmount = moveDirection * moveSpeed * Time.deltaTime;

        // OVRCameraRigの位置を更新
        ovrCameraRig.transform.position += moveAmount;
    }

}