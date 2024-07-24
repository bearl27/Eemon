using System.Collections;
using UnityEngine;

public class DeerSound : MonoBehaviour
{
    public AudioClip deerCry; // Inspectorから設定
    public float minTime = 1.0f; // 最短間隔
    public float maxTime = 10.0f; // 最長間隔

    private void Start()
    {
        StartCoroutine(PlaySoundRandomly());
    }

    private IEnumerator PlaySoundRandomly()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
            // 指定した音源を再生
            AudioSource.PlayClipAtPoint(deerCry, transform.position);
        }
    }
}