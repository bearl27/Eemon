using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakoManager : MonoBehaviour
{
    public static bool canInstantiate = false;
    public static bool gameOver = false;
    public AudioClip gameoverSound;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            gameOver = true;
            AudioSource.PlayClipAtPoint(gameoverSound, transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("nextTako"))
        {
            canInstantiate = true;
        }
    }
}
