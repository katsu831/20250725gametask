using System;
using System.Runtime;
using TMPro;
using UnityEngine;

public class CheckManagerScript : MonoBehaviour
{
    GameControllerScript GCS;
    public int addscoer; //インスペクターから設定(加算量)
    void Start()
    {
        //GameControllerScriptを取得
        GCS = FindAnyObjectByType<GameControllerScript>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //playerと衝突したらGCSの関数呼んでスコアを加算 自分消す
        if(other.CompareTag("Player"))
        {
            GCS.AddScore(addscoer);
            Destroy(gameObject);           
        }

        //地面に衝突　自分消す
        if (other.CompareTag("Ground"))
        {
           // Debug.Log("削除");
            Destroy(gameObject);
        }
    }
}
