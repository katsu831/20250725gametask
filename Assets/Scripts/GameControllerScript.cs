using TMPro;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public int score = 0;
    public float timer;   //インスペクターから設定
    public bool isTimeOver = false;

    public GameObject TimeUptxt;      //タイムアップの表示
    public TextMeshProUGUI timerTxt;  //時間
    public TextMeshProUGUI Scoretxt;  //スコア

    void Start()
    {
        Application.targetFrameRate = 60;    //フレームレートを60に固定
        TimeUptxt.gameObject.SetActive(false); //非表示にする
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer<0)
        {
            if(!isTimeOver)
            {
                TimeUptxt.gameObject.SetActive(true);//表示する
            }
            timer = 0;
            isTimeOver = true;
        }
        //UIに反映　整数で表示
        timerTxt.text = timer.ToString("f0");
        Scoretxt.text = score.ToString("f0");
    }
    public void AddScore(int newscore)
    {
        score += newscore;
    }
}
