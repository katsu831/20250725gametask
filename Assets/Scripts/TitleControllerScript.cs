using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleControllerScript : MonoBehaviour
{
    public AudioSource BGM;
    public AudioClip bgmAC;
    public AudioClip seAC;

    bool bgmPlayOnce = false;
    void Start()
    {
        
    }

    void Update()
    {

        if(!bgmPlayOnce)//true����Ȃ��Ƃ�1�񂾂��Đ�
        {
            BGM.PlayOneShot(bgmAC);
            bgmPlayOnce = true;
        }
        if(Input.GetKeyDown(KeyCode.Space)|| Input.GetButtonDown("Fire1")) //����Space�L�[�������ꂽ��֐����Ă�
        {
            playSE();
        }
    }

    public void Transition()
    {
        SceneManager.LoadScene("Main");   //Main�V�[���ɐ؂�ւ�
    }

    public void playSE()
    {
        //SE�Đ�����0.5�b���Transition()���Ă�
        BGM.PlayOneShot(seAC);
        Invoke("Transition", 1.0f);
    }
}
