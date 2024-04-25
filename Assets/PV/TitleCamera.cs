/////////////////////////////////////////////////////////////////////
//　File name  : TitleCamera.cs                                    //
//　Objective  : タイトルシーのみの特別な挙動をするカメラ          //
//　maker      : Oyama Ryuhei                                      //
/////////////////////////////////////////////////////////////////////

using UnityEngine;

public class TitleCamera : MonoBehaviour {
    //カメラが追従するようになる指標のY座標
    const float INDEX_POS_Y = 50.0f;
    //移動先のカメラのY座標
    const float NEXTCAMERA_POS_Y = 100.0f;
    //カメラの追従速度
    const float JUMPSPEED = 100.0f;

    //プレイヤー
    GameObject player;
    //プレイヤーの位置情報
    Vector3 playerPos;

    // Use this for initialization
    void Start () {
        //プレイヤー情報の取得
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update () {
        //プレイヤーのポジションを入れる
        playerPos = player.transform.position;
        //プレイヤーがジャンプしたらしばらくしてカメラも移動
        if (playerPos.y >= INDEX_POS_Y)
        {
            //移動
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, NEXTCAMERA_POS_Y, transform.position.z), JUMPSPEED * Time.deltaTime);
        }

    }
}
