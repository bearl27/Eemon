using UnityEngine;
using TMPro;  // TextMeshProの名前空間を使用

public class BallCounter : MonoBehaviour
{
    public int ballCount = 0;  // Ball count変数
    private int textNumber;  // テキスト表示用の変数
    public TextMeshPro textDisplay;  // TextMeshProテキストオブジェクトへの参照

    static public GameObject Strike;
    static public GameObject Strike2;
    static public GameObject Out;

    void Start()
    {
        Strike = GameObject.Find("Strike");
        Strike2 = GameObject.Find("Strike2");
        Out = GameObject.Find("Out");
        Strike.SetActive(false);
        Strike2.SetActive(false);
        Out.SetActive(false);
    }

    void Update()
    {
        ballCount = ThrowBall.ballCount;  // Ball countを取得
        if(ballCount == 1){
            Strike.SetActive(true);
        }else if(ballCount == 2){
            Strike2.SetActive(true);
        }else if(ballCount == 3){
            Strike.SetActive(false);
            Strike2.SetActive(false);
            Out.SetActive(true);
        }

        if(ThrowBall.gameover){
            textDisplay.text = "StrikeOut";  // テキストを更新
        }else if(ThrowBall.clear){
            textDisplay.text = "HomeRun";  // テキストを更新
        }
    }

    static public void BallCountClear()
    {
        Strike.SetActive(false);
        Strike2.SetActive(false);
        Out.SetActive(false);
    }
}