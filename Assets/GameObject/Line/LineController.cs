/////////////////////////////////////////////////////////////////////
//　File name  : LineController.cs                                 //
//　Objective  : マップ内の線の管理                                //
//　maker      : Oyama Ryuhei                                      //
/////////////////////////////////////////////////////////////////////

using UnityEngine;

public class LineController : MonoBehaviour
{
    //線の頂点座標
    public Vector3[] vertices;
    //線の太さ
    const float WIDTH = 0.2f;

    //LineRenderer
    LineRenderer lr;

    // Use this for initialization
    void Start()
    {
        //LineRendererの初期化
        lr = gameObject.GetComponent<LineRenderer>();
        int length = vertices.Length;
        lr.positionCount = length;
        lr.startWidth = WIDTH;
        lr.endWidth = WIDTH;
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //プレイヤーと線が衝突
        if (collision.tag == "Player")
        {
            if (gameObject.tag == "Road")
            {
                //プレイヤーを取得
                GameObject player = GameObject.Find("Player");
                //線の頂点情報をセット
                player.GetComponent<PlayerController>().vertices = vertices;
            }
        }

        //敵と線が衝突
        if(collision.tag == "Enemy")
        {
            if(gameObject.tag == "Road")
            {
                //敵を取得
                GameObject enemy = GameObject.Find("Enemy");
                //線の頂点情報をセット
                enemy.GetComponent<EnemyController>().vertices = vertices;
            }
        }
    }
}
