using UnityEngine;
using UnityEngine.SceneManagement;

public class DistanceCalculator : MonoBehaviour
{
    public GameObject chawan;
    public GameObject chawan1;
    public GameObject chawan2;
    public GameObject chawan3;
    public GameObject chawan4;
    public GameObject chawan5;
    public GameObject kyuusu;

    public GameObject GameClear;
    public AudioClip sound1; // Add your audio clip here
    public AudioClip gameclear;
    private AudioSource audioSource;
    private float counter = 0f;
    private bool clear = false;
    private bool audioPlay = false;

    void Start()
    {
        GameObject[] chawans = GameObject.FindGameObjectsWithTag("chawan");

        foreach (GameObject obj in chawans)
        {
            obj.SetActive(false);
        }
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = sound1;

        GameClear.SetActive(false);
        clear = false;
    }

    void Update()
    {
        Vector3 chawanPos = new Vector3(chawan.transform.position.x, 0, chawan.transform.position.z);
        Vector3 kyuusuPos = new Vector3(kyuusu.transform.position.x, 0, kyuusu.transform.position.z);

        float distance = Vector3.Distance(chawanPos, kyuusuPos);
        //print(distance);

        if(kyuusu.transform.position.y >= 0.2f && kyuusu.transform.position.y <= 0.5f && distance < 0.2f)
        {
            if (counter == 0f)
            {
                audioSource.Play();
            }
            counter += 1f;

            audioSource.UnPause(); // 再開
        }else
        {
            audioSource.Pause(); // 停止
        }

        //counter += 1f;
        //audioSource.PlayOneShot(sound1);

        if (counter >= 0f && counter <= 100f)
        {
            chawan.SetActive(true);
        }
        else if (counter >= 100f && counter < 200f)
        {
            chawan.SetActive(false);
            chawan1.SetActive(true);
        }
        else if (counter >= 200f && counter < 300f)
        {
            chawan1.SetActive(false);
            chawan2.SetActive(true);
        }
        else if (counter >= 300f && counter < 400f)
        {
            chawan2.SetActive(false);
            chawan3.SetActive(true);
        }
        else if (counter >= 400f && counter < 500f)
        {
            chawan3.SetActive(false);
            chawan4.SetActive(true);
        }
        else if (counter >= 500f && counter < 600f)
        {
            chawan4.SetActive(false);
            chawan5.SetActive(true);
        }
        else if (counter >= 600f)
        {
            chawan5.SetActive(true);
            GameClear.SetActive(true);
            clear = true;
        }

        if(clear){
            counter = 0f;
            audioPlay = true;
            if(audioPlay){
                audioSource.clip = gameclear;
                audioSource.Play();
                audioPlay = false;
            }
            Invoke("gotoNextStage", 3.0f);
        }
    }

    void gotoNextStage()
    {
        clear = false;
        SceneManager.LoadScene("mattyaire");
    }
}
