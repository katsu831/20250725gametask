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

        if(!bgmPlayOnce)//trueじゃないとき1回だけ再生
        {
            BGM.PlayOneShot(bgmAC);
            bgmPlayOnce = true;
        }
        if(Input.GetKeyDown(KeyCode.Space)|| Input.GetButtonDown("Fire1")) //もしSpaceキーが押されたら関数を呼ぶ
        {
            playSE();
        }
    }

    public void Transition()
    {
        SceneManager.LoadScene("Main");   //Mainシーンに切り替え
    }

    public void playSE()
    {
        //SE再生した0.5秒後にTransition()を呼ぶ
        BGM.PlayOneShot(seAC);
        Invoke("Transition", 1.0f);
    }
}
