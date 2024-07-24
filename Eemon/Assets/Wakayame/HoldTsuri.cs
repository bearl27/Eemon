using UnityEngine;

public class HoldTsuri : MonoBehaviour
{
    public Transform controllerTransform;

    void Update()
    {
        transform.position = controllerTransform.position;
        transform.rotation = controllerTransform.rotation;
    }
}