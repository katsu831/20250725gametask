using System;
using System.Runtime;
using TMPro;
using UnityEngine;

public class CheckManagerScript : MonoBehaviour
{
    GameControllerScript GCS;
    public int addscoer; //�C���X�y�N�^�[����ݒ�(���Z��)
    void Start()
    {
        //GameControllerScript���擾
        GCS = FindAnyObjectByType<GameControllerScript>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //player�ƏՓ˂�����GCS�̊֐��Ă�ŃX�R�A�����Z ��������
        if(other.CompareTag("Player"))
        {
            GCS.AddScore(addscoer);
            Destroy(gameObject);           
        }

        //�n�ʂɏՓˁ@��������
        if (other.CompareTag("Ground"))
        {
           // Debug.Log("�폜");
            Destroy(gameObject);
        }
    }
}
