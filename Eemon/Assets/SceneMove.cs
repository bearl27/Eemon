using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemover : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hyogo"))
        {
            SceneManager.LoadScene("Hyogo");
        }

        if(other.gameObject.CompareTag("Nara"))
        {
            SceneManager.LoadScene("Nara");
        }

        if(other.gameObject.CompareTag("Wakayama"))
        {
            SceneManager.LoadScene("Wakayama");
        }

        if(other.gameObject.CompareTag("Osaka"))
        {
            SceneManager.LoadScene("Osaka");
        }

        if(other.gameObject.CompareTag("Mie"))
        {
            SceneManager.LoadScene("Mie");
        }
        if(other.gameObject.CompareTag("Kyoto"))
        {
            SceneManager.LoadScene("hotwater");
        }
        if(other.gameObject.CompareTag("Shika"))
        {
            SceneManager.LoadScene("Shika");
        }
        if(other.gameObject.CompareTag("Home"))
        {
            SceneManager.LoadScene("Home");
        }
    }

}