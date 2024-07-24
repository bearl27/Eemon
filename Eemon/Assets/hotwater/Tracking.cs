using UnityEngine;

public class Tracking : MonoBehaviour
{
    public Transform targetA; // 追従先のTransform

    private Transform myTransform; // 自身のTransform

    void Start()
    {
        myTransform = GetComponent<Transform>(); // 自身のTransformを取得
    }

    void Update()
    {
            // 追従先の位置を自身に反映させる
            myTransform.position = targetA.position;
            //print(targetA.position);

    }
}
