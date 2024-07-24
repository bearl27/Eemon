using UnityEngine;

public class FishMovement : MonoBehaviour
{
     float speed = 1.0f;  // 魚の移動速度
     float directionChangeInterval = 3.0f;  // 方向転換の間隔（秒）
    private float heading;  // 現在の進行方向
    private float targetHeading;  // 目標の進行方向

    private float minX = -2f, maxX = 2f, minZ = 2f, maxZ = 5f;  // 移動範囲
    private float timer;  // 方向転換用タイマー
    private float centerZ = 2.7f;  // 中心のZ座標
    private float stopTime = 0;  // 釣り中の停止時間
    private int currentReel = 0;  // 現在のリール数

    void Start()
    {
        // 初期方向を設定
        heading = Random.Range(0, 360);
        transform.eulerAngles = new Vector3(0, heading, 0);
        timer = directionChangeInterval;
    }

    void Update()
    {
        if(currentReel != Fishing.reelCount && currentReel != 2)
        {
            // 魚の数が変わった場合、停止時間を設定
            stopTime = 1.0f;
            currentReel = Fishing.reelCount;
        }
        if(stopTime > 0)
        {
            stopTime -= Time.deltaTime;
            return;
        }

        if (Fishing.isFishing)
        {
            // 釣り中の場合、上方向に移動
            transform.position += Vector3.up * speed * Time.deltaTime;
            // x軸に-70度回転
            transform.rotation = Quaternion.Euler(-70, transform.eulerAngles.y, transform.eulerAngles.z);
        }
        else
        {
            // 通常の移動処理
            timer -= Time.deltaTime;
            // 現在の方向に向かって進む
            transform.position += transform.forward * speed * Time.deltaTime;

            // 範囲を超えた場合は方向転換
            if (transform.position.x < minX || transform.position.x > maxX ||
                transform.position.z < minZ || transform.position.z > maxZ)
            {
                SetHeadingTowardsCenter();
                timer = directionChangeInterval;
            }

            if (timer <= 0)
            {
                SetRandomHeading();
                timer = directionChangeInterval;
            }
        }
    }

    void SetRandomHeading()
    {
        heading = Random.Range(0, 360);
        transform.eulerAngles = new Vector3(0, heading, 0);
    }

    void SetHeadingTowardsCenter()
    {
        Vector3 centerDirection = new Vector3(0, 0, centerZ
        ) - transform.position;
        targetHeading = Mathf.Atan2(centerDirection.x, centerDirection.z) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, targetHeading, 0);
        heading = targetHeading;
    }
}