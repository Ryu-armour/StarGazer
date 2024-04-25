/////////////////////////////////////////////////////////////////////
//　File name  : CameraController.cs                               //
//　Objective  : カメラの管理                                      //
//　maker      : Oyama Ryuhei                                      //
/////////////////////////////////////////////////////////////////////

using UnityEngine;

public class CameraController : MonoBehaviour {
    //次のカメラのY座標の移動先
    const float nextCameraPosY = 100.0f;
    //ジャンプの速度
    const float jumpSpeed = 150.0f;

    //プレイヤー
    GameObject player;
    //プレイヤーの座標
    Vector3 playerPos;
	// Use this for initialization
	void Start () {
        //プレイヤー情報の取得
        player = GameObject.Find("Player");
	}

    // Update is called once per frame
    void Update()
    {
        //プレイヤーのポジションを入れる
        playerPos = player.transform.position;
        //プレイヤーがジャンプしたらしばらくしてカメラも移動
        if(playerPos.y >=  50.0f)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, nextCameraPosY, transform.position.z), jumpSpeed * Time.deltaTime);
        }
    }
}
