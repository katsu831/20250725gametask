using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControllerScript : MonoBehaviour
{
    GameControllerScript GCS;
    GameObject GCobj;

    public Rigidbody2D RB2D;
    public SpriteRenderer SR; 
    public float playerSpeed;  //インスペクターから設定
    public float playerX;      //横方向
    public float moveRange;    //行動範囲制限

    private Vector3 statPos;

    void Start()
    {
        //初期位置
        statPos = transform.position;
        //取得
        RB2D = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();

        GCobj = GameObject.Find("GameController");
        GCS = FindAnyObjectByType<GameControllerScript>();
    }

    void Update()
    {
        //キー入力されたら動く(水平方向に1,0,-1)
        playerX = Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(playerX)!=0&&!GCS.isTimeOver)
        {
            //移動を実行
            PlayerMovement(playerX);
        }
        
    }
    public void PlayerMovement(float playerX)
    {
        SR.flipX = playerX > 0;  //右入力で反転

        Vector3 playermove = Vector3.right * playerX * playerSpeed * Time.deltaTime; //移動量の計算(移動方向，速度，移動量)
        Vector3 newPos = transform.position + playermove;  //今の位置に移動量を足して次の位置計算

        //範囲制限
        var MinX = statPos.x - moveRange;
        var MaxX = statPos.x + moveRange;
        newPos.x = Mathf.Clamp(newPos.x, MinX, MaxX);

        //位置更新
        transform.position = newPos;

    }
}