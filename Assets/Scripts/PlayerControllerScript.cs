using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControllerScript : MonoBehaviour
{
    GameControllerScript GCS;
    GameObject GCobj;

    public Rigidbody2D RB2D;
    public SpriteRenderer SR; 
    public float playerSpeed;  //�C���X�y�N�^�[����ݒ�
    public float playerX;      //������
    public float moveRange;    //�s���͈͐���

    private Vector3 statPos;

    void Start()
    {
        //�����ʒu
        statPos = transform.position;
        //�擾
        RB2D = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();

        GCobj = GameObject.Find("GameController");
        GCS = FindAnyObjectByType<GameControllerScript>();
    }

    void Update()
    {
        //�L�[���͂��ꂽ�瓮��(����������1,0,-1)
        playerX = Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(playerX)!=0&&!GCS.isTimeOver)
        {
            //�ړ������s
            PlayerMovement(playerX);
        }
        
    }
    public void PlayerMovement(float playerX)
    {
        SR.flipX = playerX > 0;  //�E���͂Ŕ��]

        Vector3 playermove = Vector3.right * playerX * playerSpeed * Time.deltaTime; //�ړ��ʂ̌v�Z(�ړ������C���x�C�ړ���)
        Vector3 newPos = transform.position + playermove;  //���̈ʒu�Ɉړ��ʂ𑫂��Ď��̈ʒu�v�Z

        //�͈͐���
        var MinX = statPos.x - moveRange;
        var MaxX = statPos.x + moveRange;
        newPos.x = Mathf.Clamp(newPos.x, MinX, MaxX);

        //�ʒu�X�V
        transform.position = newPos;

    }
}