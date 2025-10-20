using System.Collections;
using UnityEditor.Build.Content;
using UnityEngine;


//  https://nosystemnolife.com/unity-avoidgame002/   ���Q��(�I�u�W�F�N�g�v�[���͂悭�킩��Ȃ������ׁ~)
public class FishControllerScript : MonoBehaviour
{
    GameControllerScript GCS;
    public static FishControllerScript Instance { get; private set; }

    public GameObject fishprefab;

    void Start()
    {
        Instance = this;
        //GameControllerScript���擾 isTimeOver���m�F����ׂɎQ��
        GCS = FindAnyObjectByType<GameControllerScript>();
        StartCoroutine(FishGenerate());
    }

    void Update()
    {
        
    }

    public IEnumerator FishGenerate()
    {
        //isTimeOver��true�ɂȂ�܂�1�b���ƂɃ����_���Ȉʒu�ɋ��𐶐�
        while(!GCS.isTimeOver)
        {
            Vector3 FishPos = new Vector3(Random.Range(-8.0f, 8.0f), 6.0f, 0);
            Instantiate(fishprefab, FishPos, Quaternion.identity);

            yield return new WaitForSeconds(1.0f);
        }
        
    }
}
