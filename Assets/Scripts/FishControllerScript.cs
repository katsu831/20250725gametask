using System.Collections;
using UnityEditor.Build.Content;
using UnityEngine;


//  https://nosystemnolife.com/unity-avoidgame002/   を参照(オブジェクトプールはよくわからなかった為×)
public class FishControllerScript : MonoBehaviour
{
    GameControllerScript GCS;
    public static FishControllerScript Instance { get; private set; }

    public GameObject fishprefab;

    void Start()
    {
        Instance = this;
        //GameControllerScriptを取得 isTimeOverを確認する為に参照
        GCS = FindAnyObjectByType<GameControllerScript>();
        StartCoroutine(FishGenerate());
    }

    void Update()
    {
        
    }

    public IEnumerator FishGenerate()
    {
        //isTimeOverがtrueになるまで1秒ごとにランダムな位置に魚を生成
        while(!GCS.isTimeOver)
        {
            Vector3 FishPos = new Vector3(Random.Range(-8.0f, 8.0f), 6.0f, 0);
            Instantiate(fishprefab, FishPos, Quaternion.identity);

            yield return new WaitForSeconds(1.0f);
        }
        
    }
}
