using TMPro;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public int score = 0;
    public float timer;   //�C���X�y�N�^�[����ݒ�
    public bool isTimeOver = false;

    public GameObject TimeUptxt;      //�^�C���A�b�v�̕\��
    public TextMeshProUGUI timerTxt;  //����
    public TextMeshProUGUI Scoretxt;  //�X�R�A

    void Start()
    {
        Application.targetFrameRate = 60;    //�t���[�����[�g��60�ɌŒ�
        TimeUptxt.gameObject.SetActive(false); //��\���ɂ���
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer<0)
        {
            if(!isTimeOver)
            {
                TimeUptxt.gameObject.SetActive(true);//�\������
            }
            timer = 0;
            isTimeOver = true;
        }
        //UI�ɔ��f�@�����ŕ\��
        timerTxt.text = timer.ToString("f0");
        Scoretxt.text = score.ToString("f0");
    }
    public void AddScore(int newscore)
    {
        score += newscore;
    }
}
